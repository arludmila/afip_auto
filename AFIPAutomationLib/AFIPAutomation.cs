using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Globalization;
namespace AFIPAutomationLib
{
    public class AFIPAutomation
    {
        private IWebDriver driver;

        public AFIPAutomation()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("protocol_handler.allowed_origin_protocol_pairs", new Dictionary<string, object>
                {
                    { "https://api.whatsapp.com", new Dictionary<string, object> { { "whatsapp", true } } }
                });
            driver = new ChromeDriver(options);


            driver.Manage().Window.Maximize();
        }

        private void LoginToAfip()
        {
            // TODO: revisar aca, deberia ser algo seguro, no esto
            // Get username and password from a text file
            var credentials = GetCredentials(@"G:\AFIP\uAp.txt");
            string username = credentials.Item1;
            string password = credentials.Item2;

            driver.Navigate().GoToUrl("https://auth.afip.gob.ar/contribuyente_/login.xhtml");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement usernameField = wait.Until(d => d.FindElement(By.Id("F1:username")));
            usernameField.SendKeys(username);
            usernameField.SendKeys(Keys.Enter);

            IWebElement passwordField = wait.Until(d => d.FindElement(By.Id("F1:password")));
            passwordField.SendKeys(password);

            IWebElement loginButton = wait.Until(d => d.FindElement(By.Id("F1:btnIngresar")));
            loginButton.Click();
        }
        private Tuple<string, string> GetCredentials(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length >= 2)
            {
                string username = lines[0].Trim();
                string password = lines[1].Trim();
                return new Tuple<string, string>(username, password);
            }
            else
            {
                throw new Exception("Invalid credentials file format.");
            }
        }
        public string IsValidCuit(string cuit)
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.cuitonline.com/");

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement cuitInput = wait.Until(d => d.FindElement(By.XPath("//*[@id='searchBox']")));
                cuitInput.SendKeys(cuit);
                cuitInput.SendKeys(Keys.Enter);

                // Wait for the results element and check its text
                IWebElement resultsCountDiv = wait.Until(d => d.FindElement(By.XPath("//*[@id='filtersMenu']/div[1]")));
                string divText = resultsCountDiv.Text;
                IWebElement nameH2 = wait.Until(d => d.FindElement(By.XPath("//*[@id=\"searchResults\"]/div[2]/div[1]/a/h2")));
                string nameH2Text = nameH2.Text;
                return nameH2Text;
                //return divText == "1 persona encontrada";
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"NoSuchElementException: {ex.Message}");
                return string.Empty;
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine($"WebDriverTimeoutException: {ex.Message}");
                return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Exception: {ex.Message}");
                throw;
            }
        }

        public void GenerateReceipt(string condicionIVA, string cuit, string productDescription, int productAmount, double totalAmount, bool useYesterdayDate)
        {
            LoginToAfip();
            // Click "Comprobantes en linea"
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement receiptsH3 = wait.Until(d => d.FindElement(By.XPath("//*[@id='serviciosMasUtilizados']/div/div/div/div[1]/a/div/h3")));
            receiptsH3.Click();

            // Switch to the new window/tab
            wait.Until(d => d.WindowHandles.Count > 1);
            driver.SwitchTo().Window(driver.WindowHandles[1]);

            IWebElement taxpayerInput = wait.Until(d => d.FindElement(By.XPath("//*[@id=\"contenido\"]/form/table/tbody/tr[4]/td/input[2]")));//*[@id="contenido"]/form/table/tbody/tr[4]/td/input[2]
            taxpayerInput.Click();

            // Click on "Generar comprobantes"
            IWebElement generateR_a = wait.Until(d => d.FindElement(By.Id("btn_gen_cmp")));
            generateR_a.Click();

            // Select the "Punto de Venta"
            IWebElement outletSelect = wait.Until(d => d.FindElement(By.Id("puntodeventa")));
            SelectElement select = new SelectElement(outletSelect);
            select.SelectByValue("2");

            // Handle optional "No mostrar" checkbox
            try
            {
                IWebElement doNotShowInput = wait.Until(d => d.FindElement(By.Id("novolveramostrar")));
                doNotShowInput.Click();
            }
            catch (NoSuchElementException) { }

            // Select the receipt type
            IWebElement typeSelect = wait.Until(d => d.FindElement(By.Id("universocomprobante")));
            select = new SelectElement(typeSelect);
            select.SelectByValue("2");

            // Continue to the next step
            IWebElement continueButton = wait.Until(d => d.FindElement(By.XPath("//*[@id='contenido']/form/input[2]")));
            continueButton.Click();

            // Optionally adjust the date if useYesterdayDate is true
            if (useYesterdayDate)
            {
                IWebElement dateInput = wait.Until(d => d.FindElement(By.Id("fc")));
                string dateText = dateInput.GetAttribute("value");
                DateTime dateObj = DateTime.ParseExact(dateText, "dd/MM/yyyy", null);
                string previousDayStr = dateObj.AddDays(-1).ToString("dd/MM/yyyy");
                dateInput.Clear();
                dateInput.SendKeys(previousDayStr);
            }

            // Select "Productos"
            IWebElement conceptSelect = wait.Until(d => d.FindElement(By.Id("idconcepto")));
            select = new SelectElement(conceptSelect);
            select.SelectByValue("1");

            // Continue to the next step
            continueButton = wait.Until(d => d.FindElement(By.XPath("//*[@id='contenido']/form/input[2]")));
            continueButton.Click();

            // Select "Consumidor Final"
            IWebElement ivaConditionSelect = wait.Until(d => d.FindElement(By.Id("idivareceptor")));
            select = new SelectElement(ivaConditionSelect);
            if (condicionIVA.Equals("CONSUMIDOR FINAL"))
            {
                select.SelectByValue("5");
            }
            else if (condicionIVA.Equals("IVA RESPONSABLE INSCRIPTO"))
            {
                select.SelectByValue("1");
            }
            else if (condicionIVA.Equals("IVA SUJETO EXENTO"))
            {
                select.SelectByValue("4");
            }
            IWebElement cashCheckbox = wait.Until(d => d.FindElement(By.Id("formadepago1")));
            if (!cuit.Equals(string.Empty))
            {
                IWebElement docNumInput = wait.Until(d => d.FindElement(By.Name("nroDocReceptor")));
                IWebElement docTypeSelect = wait.Until(d => d.FindElement(By.Id("idtipodocreceptor")));
                select = new SelectElement(docTypeSelect);
                select.SelectByText("CUIT");

                docNumInput.Clear();
                docNumInput.SendKeys(cuit);
                cashCheckbox.Click();

                By inputLocator = By.Id("razonsocialreceptor");

                wait.Until(driver => IsInputFilled(driver, inputLocator));
            }
            else
            {
                cashCheckbox.Click();

            }


            // Continue to the next step
            continueButton = wait.Until(d => d.FindElement(By.XPath("//*[@id='contenido']/form/input[2]")));
            continueButton.Click();

            // Enter product description and amount
            IWebElement productTextarea = wait.Until(d => d.FindElement(By.Id("detalle_descripcion1")));
            productTextarea.Clear();
            productTextarea.SendKeys(productDescription);

            IWebElement productQuantityInput = wait.Until(d => d.FindElement(By.XPath("//*[@id='detalle_cantidad1']")));
            productQuantityInput.Clear();
            productQuantityInput.SendKeys(productAmount.ToString());

            // Select "Unidades"
            IWebElement productUnitSelect = wait.Until(d => d.FindElement(By.Id("detalle_medida1")));
            select = new SelectElement(productUnitSelect);
            select.SelectByText("unidades");

            // Find the element for 'decimal precision'
            IWebElement decimalPrecisionElement = wait.Until(d => d.FindElement(By.XPath("//*[@id='numdecimalespreciounit']")));
            SelectElement selectPrecision = new SelectElement(decimalPrecisionElement);
            selectPrecision.SelectByValue("4");

            // Enter product price

            IWebElement pricePerUnitInput = wait.Until(d => d.FindElement(By.Id("detalle_precio1")));
            pricePerUnitInput.Clear();
            string formattedPricePerUnit = (totalAmount / productAmount).ToString("F4", CultureInfo.InvariantCulture);

            // Input the formatted price
            pricePerUnitInput.SendKeys(formattedPricePerUnit);

            // Continue to finalize
            continueButton = wait.Until(d => d.FindElement(By.XPath("//*[@id='contenido']/form/input[8]")));
            continueButton.Click();
        }
        private bool IsInputFilled(IWebDriver driver, By locator)
        {
            try
            {
                var element = driver.FindElement(locator);
                return !string.IsNullOrWhiteSpace(element.GetAttribute("value"));
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void OpenWhatsAppWithPhoneNumber(string phoneNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            string whatsappUrl = $"https://api.whatsapp.com/send?phone=54{phoneNumber}";

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.open();");

            driver.SwitchTo().Window(driver.WindowHandles.Last());

            driver.Navigate().GoToUrl(whatsappUrl);


        }
        public void CloseWebDriver()
        {
            driver.Quit();
        }

    }

}

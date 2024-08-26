using AFIPAutomationLib;
using Data.Context;
using Data.Entities;
using Data.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace App
{
    //IDEA: + desde 1 PDF de una factura que genere una nota de credito con los datos de esa factura, seria para anular esa factura!, solo necesitaria del PDF, nada mas
    public partial class Main : Form
    {
        private AFIPAutomation automation;
        private Form alertForm;
        private ClientRepository _clientRepository;
        private AFIPContext _context;
        private Client client;
        public Main()
        {
            StartPosition = FormStartPosition.CenterScreen;
            _context = new AFIPContext();
            _clientRepository = new ClientRepository(_context);

            InitializeComponent();
        }

        private void buttonCrearFactura_Click(object sender, EventArgs e)
        {
            string condicionIVA = comboBoxCondicionIVA.Text;
            string cuit = textBoxCUIT.Text;
            string detalle = comboBoxDetalle.Text;
            string cantidad = textBoxCantidad.Text;
            string precioTotal = textBoxPrecioTotal.Text;
            string celular = textBoxCelular.Text;

            // Fields validation
            if (!IsValidCondicionIVA(condicionIVA))
            {
                MessageBox.Show("La condición frente al IVA no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsValidCUIT(cuit))
            {
                MessageBox.Show("El CUIT debe ser un número de 11 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidDetalle(detalle))
            {
                MessageBox.Show("El detalle no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidCantidad(cantidad))
            {
                MessageBox.Show("La cantidad debe ser un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidPrecioTotal(precioTotal))
            {
                MessageBox.Show("El precio total debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidCelular(celular))
            {
                MessageBox.Show("El celular debe ser un número de 10 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Disable the main form interaction
            this.Enabled = false;

            // Show alert form

            if (cuit.IsNullOrEmpty())
            {
                ShowAlertFormNoCuit();
            }
            else
            {
                ShowAlertFormWithCuit();
            }

            // Start the automation process
            automation = new AFIPAutomation();

            // Execute automation logic

            if (!String.IsNullOrEmpty(cuit))
            {
                // TODO: esto deberia ejecutarse mejor al haber puesto un CUIT de 11 digitos, entonces se valida ya y se muestra el nombrecito al lado del input. 
                string cuitName = automation.IsValidCuit(cuit);
                if (!cuitName.IsNullOrEmpty())
                {
                    client = new Client
                    {
                        CUIT = cuit,
                        PhoneNumber = celular,
                        Name = cuitName,
                    };
                    automation.GenerateReceipt(condicionIVA, cuit, detalle, int.Parse(cantidad), double.Parse(precioTotal), false);
                    automation.OpenWhatsAppWithPhoneNumber(celular);
                }

            }

            else
            {
                automation.GenerateReceipt(condicionIVA, cuit, detalle, int.Parse(cantidad), double.Parse(precioTotal), false);
                automation.OpenWhatsAppWithPhoneNumber(celular);
            }
        }

        private void ShowAlertFormWithCuit()
        {

            alertForm = new Form
            {
                Text = "Confirmación",
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen,
                Size = new System.Drawing.Size(300, 150),
                ControlBox = false
            };


            Label messageLabel = new Label
            {
                Text = "¿Está seguro de que desea agregar este cliente a la base de datos?",
                Dock = DockStyle.Top,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Padding = new Padding(10),
                Height = 60
            };


            System.Windows.Forms.Button confirmButton = new System.Windows.Forms.Button
            {
                Text = "Confirmar",
                BackColor = Color.Green,
                ForeColor = Color.White,
                Location = new Point(10, 100),
                Size = new Size(130, 30),
                FlatStyle = FlatStyle.Flat
            };

            confirmButton.Click += ConfirmButtonWithCuit_Click;

            System.Windows.Forms.Button closeButton = new System.Windows.Forms.Button
            {
                Text = "Cancelar",
                BackColor = Color.Red,
                ForeColor = Color.White,
                Location = new Point(160, 100),
                Size = new Size(130, 30),
                FlatStyle = FlatStyle.Flat
            };

            closeButton.Click += CloseButton_Click;

            alertForm.Controls.Add(messageLabel);
            alertForm.Controls.Add(confirmButton);
            alertForm.Controls.Add(closeButton);

            alertForm.FormClosed += AlertForm_FormClosed;
            alertForm.Show();
        }


        private async void ConfirmButtonWithCuit_Click(object sender, EventArgs e)
        {
            try
            {
                string resultMessage = await _clientRepository.AddClientAsync(client);

                MessageBox.Show(resultMessage, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (resultMessage == "Cliente agregado a la base de datos exitosamente.")
                {
                    await LoadClientsAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el cliente a la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseAlertForm();
            }
        }



        private void CloseButton_Click(object sender, EventArgs e)
        {
            CloseAlertForm();
        }

        private void CloseAlertForm()
        {
            textBoxCUIT.Clear();
            comboBoxDetalle.SelectedIndex = -1;
            textBoxCantidad.Clear();
            textBoxPrecioTotal.Clear();
            textBoxCelular.Clear();

            alertForm?.Close();

            this.Enabled = true;
        }
        private void ShowAlertFormNoCuit()
        {
            
            alertForm = new Form
            {
                Text = "Procesando",
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen,
                Size = new System.Drawing.Size(300, 150),
                ControlBox = false 
            };

            Label messageLabel = new Label
            {
                Text = "Se está ejecutando o realizando una factura. El proceso se cerrará automáticamente al cerrar este mensaje.",
                Dock = DockStyle.Top,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Padding = new Padding(10),
                Height = 100 
            };

            System.Windows.Forms.Button closeButton = new System.Windows.Forms.Button
            {
                Text = "Cerrar Proceso",
                BackColor = Color.Red,
                ForeColor = Color.White,
                Dock = DockStyle.Bottom,
                FlatStyle = FlatStyle.Flat
            };

            closeButton.Click += CloseButton_Click;

            alertForm.Controls.Add(messageLabel);
            alertForm.Controls.Add(closeButton);

            alertForm.FormClosed += AlertForm_FormClosed;
            alertForm.Show();
        }


        private void AlertForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            automation?.CloseWebDriver();
            this.Enabled = true;
        }
        private bool IsValidCUIT(string cuit)
        {
            return string.IsNullOrEmpty(cuit) || (cuit.Length == 11 && long.TryParse(cuit, out _));
        }

        private bool IsValidDetalle(string detalle)
        {
            return !string.IsNullOrWhiteSpace(detalle);
        }
        private bool IsValidCondicionIVA(string detalle)
        {
            return !string.IsNullOrWhiteSpace(detalle);
        }
        private bool IsValidCantidad(string cantidad)
        {
            return int.TryParse(cantidad, out _);
        }
        private bool IsValidPrecioTotal(string precioTotal)
        {
            return double.TryParse(precioTotal, out _);
        }
        private bool IsValidCelular(string celular)
        {
            return celular.Length == 10 && long.TryParse(celular, out _);
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            comboBoxCondicionIVA.SelectedItem = null;

            comboBoxCondicionIVA.SelectedText = "CONSUMIDOR FINAL";
            await LoadClientsAsync();
        }
        private async Task LoadClientsAsync()
        {
            try
            {
                var clients = await _clientRepository.GetAllClientsAsync();
                dataGridViewClients.DataSource = null;
                dataGridViewClients.DataSource = clients;
                StyleDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading clients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleDataGridView()
        {
            dataGridViewClients.RowHeadersVisible = false;

            dataGridViewClients.Columns["CUIT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewClients.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewClients.Columns["PhoneNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridViewClients.Columns["CUIT"].FillWeight = 25;
            dataGridViewClients.Columns["Name"].FillWeight = 50;
            dataGridViewClients.Columns["PhoneNumber"].FillWeight = 25;

            dataGridViewClients.Columns["CUIT"].HeaderText = "CUIT";
            dataGridViewClients.Columns["Name"].HeaderText = "Nombre";
            dataGridViewClients.Columns["PhoneNumber"].HeaderText = "Número de Telefono";

            dataGridViewClients.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewClients.ReadOnly = true;
        }

        private async void textBoxSearchClients_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearchClients.Text.ToLower();

            var clients = await _clientRepository.GetAllClientsAsync();

            var filteredClients = clients.Where(client =>
                client.CUIT.ToLower().Contains(searchText) ||
                client.Name.ToLower().Contains(searchText) ||
                client.PhoneNumber.ToLower().Contains(searchText)
            ).ToList();

            dataGridViewClients.DataSource = filteredClients;
        }

        private void dataGridViewClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewClients.Rows[e.RowIndex];

                string cuit = row.Cells["CUIT"].Value?.ToString();
                textBoxCUIT.Text = cuit;
            }
        }
    }


}

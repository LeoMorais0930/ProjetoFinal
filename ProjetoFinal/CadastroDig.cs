using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using NITGEN.SDK.NBioBSP;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoFinal
{
    public partial class CadastroDig : Form
    {
        private NBioAPI m_NBioAPI;
        private short currentDeviceID = -1;

        public CadastroDig()
        {
            InitializeComponent();
            InitializeNBioBSP();
            // Adicionar essas linhas para tela cheia
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeNBioBSP()
        {
            m_NBioAPI = new NBioAPI();
            EnumerateDevices();
        }

        private void EnumerateDevices()
        {
            int i;
            uint nNumDevice;
            short[] nDeviceID;
            NBioAPI.Type.DEVICE_INFO_EX[] deviceInfoEx;
            uint ret = m_NBioAPI.EnumerateDevice(out nNumDevice, out nDeviceID, out deviceInfoEx);
            if (ret == NBioAPI.Error.NONE)
            {
                comboBoxDispositivo.Items.Add("Auto_Detect");
                for (i = 0; i < nNumDevice; i++)
                {
                    comboBoxDispositivo.Items.Add(deviceInfoEx[i].Name);
                }
            }
            else
            {
                MessageBox.Show("Erro ao enumerar dispositivos: " + ret.ToString());
            }
        }

        private void btnEscolherDispositivo_Click(object sender, EventArgs e)
        {
            uint ret;
            if (comboBoxDispositivo.SelectedItem != null && comboBoxDispositivo.SelectedItem.ToString() != "Auto_Detect")
            {
                // Fechar o dispositivo atual antes de abrir outro
                if (currentDeviceID != -1)
                {
                    ret = m_NBioAPI.CloseDevice(currentDeviceID);
                    if (ret != NBioAPI.Error.NONE)
                    {
                        MessageBox.Show("Falha ao fechar o dispositivo: " + ret.ToString());
                        return;
                    }
                }
                // Abrir o dispositivo selecionado
                short deviceID = (short)(comboBoxDispositivo.SelectedIndex - 1); // Ajustar índice para Auto_Detect
                ret = m_NBioAPI.OpenDevice(deviceID);
                if (ret == NBioAPI.Error.NONE)
                {
                    currentDeviceID = deviceID;
                    MessageBox.Show("Dispositivo aberto com sucesso!");
                }
                else
                {
                    MessageBox.Show("Falha ao abrir o dispositivo: " + ret.ToString());
                }
            }
            else
            {
                // Auto detectar o dispositivo
                ret = m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                if (ret == NBioAPI.Error.NONE)
                {
                    currentDeviceID = NBioAPI.Type.DEVICE_ID.AUTO;
                    MessageBox.Show("Dispositivo aberto com sucesso!");
                }
                else
                {
                    MessageBox.Show("Falha ao abrir o dispositivo: " + ret.ToString());
                }
            }
        }
        private void btnCadastrarDigital_Click(object sender, EventArgs e)
        {
            uint ret;
            NBioAPI.Type.HFIR hNewFIR;
            ret = m_NBioAPI.Enroll(out hNewFIR, null);
            if (ret == NBioAPI.Error.NONE)
            {
                // Enroll success
                MessageBox.Show("Cadastro de impressão digital realizado com sucesso!");

                // Get binary encoded FIR data
                NBioAPI.Type.FIR biFIR;
                m_NBioAPI.GetFIRFromHandle(hNewFIR, out biFIR);

                // Get text encoded FIR data
                NBioAPI.Type.FIR_TEXTENCODE textFIR;
                m_NBioAPI.GetTextFIRFromHandle(hNewFIR, out textFIR, true);

                // Generate a unique identifier (like a GUID) to associate with this fingerprint
                string uniqueId = Guid.NewGuid().ToString();

                // Hash da impressão digital
                string hashDigital = GerarHash(textFIR.TextFIR);

                // Save the fingerprint data to the database with the unique identifier and hash
                SaveFingerprintDataToDatabase(uniqueId, hashDigital, biFIR, textFIR);

                // Após o cadastro bem-sucedido da digital, abrir o formulário CadCus
                CadCus cadCusForm = new CadCus(uniqueId);
                cadCusForm.Show();
                this.Hide();
            }
            else
            {
                // Enroll failed
                MessageBox.Show("Falha ao cadastrar a impressão digital: " + ret.ToString());
            }
        }

        private string GerarHash(string textFIR)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(textFIR));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void SaveFingerprintDataToDatabase(string uniqueId, string hashDigital, NBioAPI.Type.FIR biFIR, NBioAPI.Type.FIR_TEXTENCODE textFIR)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection("User Id=system;Password=093003;Data Source=DESKTOP-KHKU2NH:1521/FREE;Pooling=true;Min Pool Size=1;Max Pool Size=10;Connection Lifetime=120;"))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand("INSERT INTO CLIENTES (UNIQUE_ID, TEXTDATA, TEXTDATA_HASH, BINARYDATA) VALUES (:UniqueId, :TextData, :TextDataHash, :BinaryData)", connection))
                    {
                        command.Parameters.Add(new OracleParameter("UniqueId", uniqueId));
                        command.Parameters.Add(new OracleParameter("TextData", textFIR.TextFIR));
                        command.Parameters.Add(new OracleParameter("TextDataHash", hashDigital));
                        command.Parameters.Add(new OracleParameter("BinaryData", biFIR.Data));
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Dados da impressão digital salvos no banco de dados com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os dados no banco de dados: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inicio inicioForm = new Inicio();
            inicioForm.Show();
            this.Close();
        }
    }
}

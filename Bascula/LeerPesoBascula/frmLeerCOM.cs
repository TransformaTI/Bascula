using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace LeerPesoBascula
{
    public partial class frmLeerCOM : Form
    {
        public frmLeerCOM()
        {
            InitializeComponent();
        }

        private string _LecturaCOM;
        private string _Puerto;
        private string _Bauts;
        private string _Bits;
        private int _Paridad;
        private int _CParada;
        private int _Flujo;

        /// <summary>
        /// Regresa una cadena de texto con la lectura de proveniente de la bascula.        
        /// </summary>
        public string ResultadoLectura
        {
            get { return _LecturaCOM; }
        }

        /// <summary>
        /// Establece el nombre del puerto COM al que se va a conectar para obtener el peso.
        /// </summary>
        public string Puerto
        {
            set { _Puerto = value; }
        }


        public string Bauts
        {
            set { _Bauts = value; }
        }

        public string Bits
        {
            set { _Bits = value; }
        }

        /// <summary>
        /// Establece un valor entero de la paridad. 0 = Ninguno, 1 = Par, 2 = Impar.
        /// </summary>
        public int Paridad
        {
            set { _Paridad = value; }
        }

        /// <summary>
        /// Establece el bit de alto para la lectua. 0 = Ninguno, 1 = 1, 2 = 1.5, 3 = 2;
        /// </summary>
        public int ControlParada
        {
            set { _CParada = value; }
        }

        /// <summary>
        /// Estable el tipo de control de flujo de la información. 0 = Ninguno, 1 = Hardware, 2 = Xon/Xoff
        /// </summary>
        public int ControlFlujo
        {
            set { _Flujo = value; }
        }

        private SerialPort port;

        private void frmPuertoCOM_Load(object sender, EventArgs e)
        {
            //port = new SerialPort(_Puerto, int.Parse(_Bauts), Parity.None,int.Parse(_Bits), StopBits.One);

            port = new SerialPort();

            port.PortName = _Puerto;
            port.BaudRate = int.Parse(_Bauts);
            port.DataBits = int.Parse(_Bits);

            //Control de paridad
            switch (_Paridad)
            {
                case 0:
                    this.port.Parity = Parity.None;
                    break;
                case 1:
                    this.port.Parity = Parity.Even;
                    break;
                case 2:
                    this.port.Parity = Parity.Mark;
                    break;
            }

            //Control de StopBit
            switch (_CParada)
            {
                case 0:
                    this.port.StopBits = StopBits.None;
                    break;
                case 1:
                    this.port.StopBits = StopBits.One;
                    break;
                case 2:
                    this.port.StopBits = StopBits.OnePointFive;
                    break;
                case 3:
                    this.port.StopBits = StopBits.Two;
                    break;
            }

            //Control de Flujo
            switch (_Flujo)
            {
                case 0:
                    this.port.Handshake = Handshake.None;
                    break;
                case 1:
                    this.port.Handshake = Handshake.RequestToSendXOnXOff;
                    break;
                case 2:
                    this.port.Handshake = Handshake.XOnXOff;
                    break;
            }

            port.DtrEnable = true;
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            port.DiscardNull = true;

            if (port.IsOpen == false)
                try
                {
                    port.Open();
                }
                catch (Exception oex)
                {
                    MessageBox.Show(oex.ToString() + "\n" + oex.Message, "Error al abrir el puerto");
                }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(DoUpdate));
            //port.Close();
        }


        private void DoUpdate(object s, EventArgs e)
        {
            Thread.Sleep(100);

            string data = port.ReadExisting() + port.ReadExisting(); //+port.ReadExisting();

            if (data.Trim().Length > 3)
            {
                try
                {
                    _LecturaCOM = data.Trim().Remove(0, 3);
                }
                catch (Exception f)
                {
                    MessageBox.Show(f.Message.ToString(), "Error al obtener la cadena");
                }
            }
            //else
                //MessageBox.Show(data, "Información obtenida");
        }

        private void frmLeerCOM_FormClosed(object sender, FormClosedEventArgs e)
        {
            port.Close();
        }
    }
}

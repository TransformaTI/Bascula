using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;

namespace LeerPesoBascula
{
    public class AbrirEthernet
    {
        private Socket m_socClient; //Conexión de Ethernet
        private string _ResultadoValidacion = "";

        public string ResultadoValidacion
        {
            get { return _ResultadoValidacion; }
            set { _ResultadoValidacion = value; }
        }
        

        /// <summary>
        /// Valida la cadena obtenida del puerto COM y Ethernet, dependiendo de los parámetros proporcionados.
        /// </summary>
        /// <param name="Empresa">La empresa donde se ejecuta 0 Gas Metropolitano y TheoGas, 1 para Gas de Oaxaca.</param>
        /// <param name="Iniciar">Posición inicial de la lectura.</param>
        /// <param name="Largo">Longitud a leer de la cadena.</param>
        /// <param name="Caracter">Caracter del cual se va a iniciar la lectura de la cadena.</param>
        /// <returns>Devuelve una cadena de texto, con el valor del peso obtenido.</returns>
        public string ValidarCadena(int Empresa, int Iniciar, int Largo, string Caracter)
        {
            string Lectura = "";

            try
            {
                string charInicio;
                int Inicio, Longitud;
                int valor = 0;

                Inicio = Iniciar;
                Longitud = Largo;
                charInicio = Caracter;
                Lectura = _ResultadoValidacion;

                if (charInicio != string.Empty)
                {
                    Lectura = Lectura.Substring(Lectura.IndexOf(charInicio));
                }

                Lectura = Lectura.Substring(Inicio, Longitud);

                valor = int.Parse(Lectura);

                Lectura = valor.ToString();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message + "\n" + "Cadena obtenida: " + ResultadoValidacion
                //, "Erro al validar la cadena.");
                Lectura = "0";
            }  

            /*
            switch (Empresa)
            {
                    
                case 0: //GAS METROPOLITANO y THEOGAS
                    try
                    {
                        string charInicio;
                        int Inicio, Longitud;
                        int valor = 0;                        

                        Inicio = Iniciar;
                        Longitud = Largo;
                        charInicio = Caracter;
                        Lectura = _ResultadoValidacion;

                        if (charInicio != string.Empty)
                        {
                            Lectura = Lectura.Substring(Lectura.IndexOf(charInicio));
                        }                        

                        Lectura = Lectura.Substring(Inicio, Longitud);

                        valor = int.Parse(Lectura);

                        Lectura = valor.ToString();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message + "\n" + "Cadena obtenida: " + ResultadoValidacion
                        , "Erro al validar la cadena, caso 0. ");
                        Lectura = "0";
                    }                    

                    break;

                case 1: //GAS DE OAXACA
                    try
                    {
                        string charInicio;
                        int Inicio, Longitud;
                        int valor = 0;

                        Inicio = Iniciar;
                        Longitud = Largo;
                        charInicio = Caracter;

                        Lectura = _ResultadoValidacion;
                        Lectura = Lectura.Replace("\n", "");
                        Lectura = Lectura.Replace("\r", "");

                        if (charInicio != string.Empty)
                        {
                            Lectura = Lectura.Substring(Lectura.IndexOf(charInicio));
                        }

                        Lectura = Lectura.Substring(Inicio, Longitud);

                        valor = int.Parse(Lectura);

                        Lectura = valor.ToString();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message + "\n" + "Cadena obtenida: " + ResultadoValidacion,
                            "Erro al validar la cadena caso 1.");
                        Lectura = "0";
                    }
                    break;
            }
            */

            return Lectura;
        }


        /*** CÓDIGO GENERADO PARA EL USO DE ETHERNET  ****/
        
        public void AbirConexion(string IP, string Puerto)
        {
            try
            {
                //create a new client socket ...
                m_socClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                String szIPSelected = IP;
                String szPort = Puerto;
                int alPort = System.Convert.ToInt16(szPort, 10);

                System.Net.IPAddress remoteIPAddress = System.Net.IPAddress.Parse(szIPSelected);
                System.Net.IPEndPoint remoteEndPoint = new System.Net.IPEndPoint(remoteIPAddress, alPort);
                m_socClient.Connect(remoteEndPoint);
                //MessageBox.Show("Conectado");

            }
            catch (SocketException se)
            {
                MessageBox.Show("Error al conectar: " + se.Message,"Error al abrir el puerto Ethernet");
            }
        }

        public void CerrarConexion()
        {
            m_socClient.Close();
        }

        public void ObtenerDatos()
        {
            try
            {
                byte[] buffer = new byte[1024];
                int iRx = m_socClient.Receive(buffer);
                char[] chars = new char[iRx];

                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(buffer, 0, iRx, chars, 0);
                System.String szData = new System.String(chars);
                _ResultadoValidacion = szData;
            }
            catch (SocketException se)
            {
                MessageBox.Show("Error al obtener Información: " + se.Message,"Error al Obetener los datos del puerto Ethernet");
            }
        }

    }
}

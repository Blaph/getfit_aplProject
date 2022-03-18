using System;
using System.Net.Sockets;

public class Client
{
    private const string server_host = "127.0.0.1";
    private const Int32 server_port = 10000;
    private const Int32 bufSize = 2048;

    public TcpClient openConnection()
    {
        TcpClient client = new TcpClient(server_host, server_port);
        return client;
    }

    public string getData(TcpClient client, NetworkStream stream)
    {
        // Otteniamo il client stream per lettura e scrittura.
        stream = client.GetStream();

        // Riceviamo la risposta del Tcpserver.
        // Generiamo un buffer per salvare la risposta che arriverà in B.
        Byte[] data = new Byte[bufSize];

        // Stringa per salvare la risposta rappresentandola in ASCII.
        String responseData = String.Empty;

        // Leggiamo il primo batch di B di risposta in arrivo dal Tcpserver.
        Int32 bytes = stream.Read(data, 0, data.Length);
        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
        Console.WriteLine("Received: {0}", responseData);

        return responseData;
    }

    public void sendCommand(TcpClient client, string message, NetworkStream stream)
    {
        // Converti il messaggio passato in ASCII e salvalo come un vettore di B.
        Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

        // Otteniamo il client stream per lettura e scrittura.
        stream = client.GetStream();

        // Inviamo il messaggio al TcpServer cui ci siamo collegati.
        stream.Write(data, 0, data.Length);

        // Conferma del messaggio inviato.
        Console.WriteLine("Sent: {0}", message);
    }

    public void closeConnection(TcpClient client, NetworkStream stream)
    {
        stream = client.GetStream();
        // Chiudiamo tutto.
        stream.Close();
        client.Close();
    }

    public string Connect(String message)   // Usato quando si prevede una sola risposta
    {
        try
        {
            TcpClient client = new TcpClient(server_host, server_port);

            // Converti il messaggio passato in ASCII e salvalo come un vettore di B.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            
            // Otteniamo il client stream per lettura e scrittura.
            NetworkStream stream = client.GetStream();

            // Inviamo il messaggio al TcpServer cui ci siamo collegati.
            stream.Write(data, 0, data.Length);

            // Conferma del messaggio inviato.
            Console.WriteLine("Sent: {0}", message);

            // Riceviamo la risposta del Tcpserver.
            // Generiamo un buffer per salvare la risposta che arriverà in B.
            data = new Byte[bufSize];

            // Stringa per salvare la risposta rappresentandola in ASCII.
            String responseData = String.Empty;

            // Leggiamo il primo batch di B di risposta in arrivo dal Tcpserver.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);

            // Chiudiamo tutto.
            stream.Close();
            client.Close();

            // Ritorniamo i dati ricevuti.
            return responseData;
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
            return null;
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
            return null;
        }
    }
}
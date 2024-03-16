using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Receiver
{
    static void Main(string[] args)
    {
        const int listenPort = 11001; // Receiver listening on port 11001

        using (UdpClient listener = new UdpClient(listenPort))
        {
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast...");
                    byte[] bytes = listener.Receive(ref groupEP);

                    Console.WriteLine($"Received broadcast from {groupEP} :");
                    Console.WriteLine($" {Encoding.UTF8.GetString(bytes, 0, bytes.Length)}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
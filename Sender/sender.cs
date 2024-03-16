using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Sender
{
    static void Main(string[] args)
    {
        const int senderPort = 11000; // Sender's port
        const int receiverPort = 11001; // Receiver's port
        const string server = "127.0.0.1"; // Target server address

        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(server), receiverPort);
        using (UdpClient udpClient = new UdpClient(new IPEndPoint(IPAddress.Any, senderPort)))
        {
            Console.WriteLine("Enter a message to send to the receiver. Type 'exit' to quit.");
            string message;
            do
            {
                message = Console.ReadLine();
                if (!string.IsNullOrEmpty(message) && message.ToLower() != "exit")
                {
                    byte[] sendBytes = Encoding.UTF8.GetBytes(message);
                    udpClient.Send(sendBytes, sendBytes.Length, endPoint);
                }
            }
            while (message != null && message.ToLower() != "exit");
        }
    }
}
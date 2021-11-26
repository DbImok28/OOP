using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using lab5;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml;
using System.Xml.Linq;

namespace lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            Ball ball = new Ball(500);

            //Bin
            var binSer = new BinaryFormatter();
            using(var f = new FileStream("ball.data", FileMode.OpenOrCreate))
            {
                binSer.Serialize(f, ball);
            }
            using (var f = new FileStream("ball.data", FileMode.Open))
            {
                Console.WriteLine(((Ball)binSer.Deserialize(f)).ToString());
            }

            //XML
            var xmlSer = new XmlSerializer(ball.GetType());
            using (var f = new StreamWriter("ball.xml"))
            {
                xmlSer.Serialize(f, ball);
            }
            using (var f = new StreamReader("ball.xml"))
            {
                Console.WriteLine(((Ball)xmlSer.Deserialize(f)).ToString());
            }

            //SOAP
            var soapSer = new SoapFormatter();
            using (var f = new FileStream("ball.soap", FileMode.OpenOrCreate))
            {
                soapSer.Serialize(f, ball);
            }
            using (var f = new FileStream("ball.soap", FileMode.Open))
            {
                Console.WriteLine(((Ball)soapSer.Deserialize(f)).ToString());
            }

            //JSON
            string jsonData = JsonSerializer.Serialize(ball);
            using (var f = new StreamWriter("ball.json"))
            {
                f.WriteLine(jsonData);
            }
            using (var f = new StreamReader("ball.json"))
            {
                Console.WriteLine(JsonSerializer.Deserialize<Ball>(f.ReadToEnd()).ToString());
            }

            List<Ball> balls = new List<Ball>() { new Ball(123), new Ball(222) };

            CustomSerializer.SerializeToJson("balls.json", balls);
            Console.WriteLine("[");
            CustomSerializer.DeserializeJson<List<Ball>>("balls.json").ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("]");

            CustomSerializer.SerializeToXML("balls.xml", balls);
            var doc = new XmlDocument();
            doc.Load("balls.xml");
            Console.WriteLine(doc.SelectSingleNode("ArrayOfBall/Ball/Name").InnerText);
            Console.WriteLine(doc.SelectSingleNode("ArrayOfBall/Ball[2]/Weight").InnerText);

            XDocument xdoc = XDocument.Load("balls.xml");
            foreach (var item in xdoc.Elements("ArrayOfBall"))
            {
                Console.WriteLine(item.Value);
            }
            //foreach (var item in xdoc.Element("Ball").Descendants().Where(x => x.Name == "Width" && Convert.ToInt32(x.Value.ToString()) > 200).Elements())
            //{
            //    Console.WriteLine(item.Value);
            //}

            Console.ReadKey();
        }
    }
}

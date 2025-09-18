using SmartPhone.Models;

Console.WriteLine("Testando o Smartphone Nokia:");
// Instanciando a classe Nokia com os dados necessários
Smartphone nokia = new Nokia(numero: "123456789", modelo: "Nokia G21", imei: "111111111111111", memoria: 64);
nokia.Ligar();
nokia.InstalarAplicativo("WhatsApp");

Console.WriteLine("\n--------------------------\n");

Console.WriteLine("Testando o Smartphone iPhone:");
// Instanciando a classe Iphone com os dados necessários
Smartphone iphone = new Iphone(numero: "987654321", modelo: "iPhone 15 Pro", imei: "222222222222222", memoria: 256);
iphone.ReceberLigacao();
iphone.InstalarAplicativo("Telegram");

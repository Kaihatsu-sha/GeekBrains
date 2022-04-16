// See https://aka.ms/new-console-template for more information
using Kaihatsu.ASPMVC.BehavioralPatterns;
using Kaihatsu.ASPMVC.BehavioralPatterns.ChainsOfResponsibility;
using Kaihatsu.ASPMVC.BehavioralPatterns.Visitor;

Console.WriteLine("Hello, World!");
//SuperTest.Start();

string context = "Самое обычно письмо.";
string context1 = "Пароль от админа: Admin01";
// Проверить с интерфейсом
//Processor processor = new Processor()
//    .AddBlock(new ConfidentialInformationProcessor())
//    .AddBlock(new TradeSecretsProcessor())
//    .AddBlock(new PasswordPolicyProcessor());

//Processor processor = new Processor()
//    .AddBlock(new ConfidentialInformationProcessor())
//    .AddBlock(new TradeSecretsProcessor())
//    .AddBlock(new PasswordPolicyProcessor());
//processor.Run(context1);

VisitorExample visitor = new VisitorExample();
visitor.Run();

//IStrategy strategyAppend = new FileSystemAppend();
//IStrategy strategyOverwritten = new FileSystemOverwritten();
//Scaner scaner = new Scaner(strategyOverwritten);
//scaner.Scan();
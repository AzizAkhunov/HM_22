using HM_22;
using System.Data.SqlClient;

Console.WriteLine("\t\t1.Registratsiya\n\t\t2.Xabar Yuborish\n\t\t3.Xabarlarni kurish\n\t\t0.Exit");
int change = int.Parse(Console.ReadLine());
var service = new Service();
//service.CreateTable_Users();
//service.CreateTable_SMS();
switch (change)
{
    case 1:
        service.AddUser();
        break;
    case 2:
        service.AddSMS(); 
        break;
    case 3:
        service.GetAllSms();
        break;
    case 0:
        return;
}


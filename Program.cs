using System;
using System.Collections; 
using System.Collections.Generic;
namespace DMA
{
    class account{
        String customer;
        int customerID;
        ArrayList chequingAccoutNumber = new ArrayList();
        ArrayList chequingAccoutReminder = new ArrayList();

        public string Customer { get => customer; set => customer = value; }
        public int CustomerID { get => customerID; set => customerID = value; }

        public void createAccount(int number,double amount){
            if(this.chequingAccoutNumber.IndexOf(number)==-1){
                this.chequingAccoutNumber.Add(number);
                this.chequingAccoutReminder.Add(amount);
            }else{
                Console.WriteLine("We can not create this account you have this account!!!");
            }            
        }
        public double balance(int bankId){
            int id=this.chequingAccoutNumber.IndexOf(bankId);
            double res=-1;
            if(id>=0)
                 res=(double)this.chequingAccoutReminder[id];
            return res;
        }
        public void deposit(double amounth, String currency,int account, int uID){
            if(uID==this.customerID){
                int id=this.chequingAccoutNumber.IndexOf(account);
                if(id>=0){
                    switch (currency)
                    {
                        case "USD":
                            this.chequingAccoutReminder[id]=(double)this.chequingAccoutReminder[id]+(amounth *2);
                        break;
                        case "MXN":
                            this.chequingAccoutReminder[id]=(double)this.chequingAccoutReminder[id]+(amounth /10);
                        break;
                        case "CAD":
                            this.chequingAccoutReminder[id]=(double)this.chequingAccoutReminder[id]+(amounth);
                        break;
                        default:
                            Console.WriteLine("We can not Accept this currency!!!");
                        break;
                    }
                }
            }
            
        }
        public void withdraw(double amounth, String currency,int account, int uID){
            if(uID==this.customerID){
                int id=this.chequingAccoutNumber.IndexOf(account);
                if(id>=0){
                    switch (currency)
                    {
                        case "USD":
                            this.chequingAccoutReminder[id]=(double)this.chequingAccoutReminder[id]-(amounth *2);
                        break;
                        case "MXN":
                            this.chequingAccoutReminder[id]=(double)this.chequingAccoutReminder[id]-(amounth /10);
                        break;
                        case "CAD":
                            this.chequingAccoutReminder[id]=(double)this.chequingAccoutReminder[id]-(amounth);
                        break;
                        default:
                            Console.WriteLine("We can not Accept this currency!!!");
                        break;
                    }
                }
                
            }
        }
        public void transfer(double amount,int from,int to){
            withdraw(amount,"CAD",from,this.customerID);
            deposit(amount,"CAD",to,this.customerID);
        }
    }
    class jointAccount:account{
        String customer2;
        int customerID2;
        public string Customer2 { get => customer2; set => customer2 = value; }
        public int CustomerID2 { get => customerID2; set => customerID2 = value; }
        public new void withdraw(double amounth, String currency,int account, int uID){
            if(uID==this.customerID2 ||uID==base.CustomerID){
                base.withdraw(amounth, currency,account, base.CustomerID);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            account case1=new account();
            case1.Customer="Stewie Griffin";
            case1.CustomerID=777;
            case1.createAccount(1234,100);
            case1.deposit(300,"USD",1234,777);
            Console.WriteLine($"Account Number 1234 Balance:{case1.balance(1234),0:c} CAD");            
            account case2=new account();
            case2.Customer="Glenn Quagmire";
            case2.CustomerID=504;
            case2.createAccount(2001,35000);
            case2.withdraw(5000,"MXN",2001,504);
            case2.withdraw(12500,"USD",2001,504);
            case2.deposit(300,"CAD",2001,504);
            Console.WriteLine("Account Number 2001 Balance:$ "+ case2.balance(2001) +" CAD");

            account case3=new account();
            case3.Customer="Joe Swanson";
            case3.CustomerID=2;
            case3.createAccount(1010,7425);
            case3.createAccount(5500,15000);
            case3.withdraw(5000,"CAD",5500,2);
            case3.transfer(7300,1010,5500);
            case3.deposit(13726,"MXN",1010,2);
            Console.WriteLine($"Account Number 1010 Balance:{case3.balance(1010),0:c} CAD Account Number 5500 Balance:{case3.balance(5500),0:c} CAD");

            jointAccount case4=new jointAccount();
            case4.Customer="Peter Griffin";
            case4.CustomerID=123;
            case4.createAccount(123,150);
            case4.Customer2="Lois Griffin";
            case4.CustomerID2=456;
            case4.createAccount(456,65000);
            case4.withdraw(70,"USD",123,123);
            case4.deposit(23789,"USD",456,123);
            case4.transfer(23.75,456,123);
            Console.WriteLine($"Account Number 0123 Balance:{case4.balance(123),0:c} CAD Account Number 0456 Balance:{case4.balance(456),0:c} CAD");

            account case5_1=new account();
            case5_1.Customer="Joe Swanson";
            case5_1.CustomerID=2;
            case5_1.createAccount(1010,7425);
            account case5_2=new account();
            case5_2.Customer="John Shark";
            case5_2.CustomerID=219;
            case5_2.withdraw(100,"CAD",1010,219);
            Console.WriteLine($"Account Number 0123 Balance:{case5_1.balance(1010),0:c}");

        }
    }
    
}

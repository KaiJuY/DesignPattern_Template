using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //業務代表模式
    //主要有4個主要的模組
    //使用者、業務代表、業務搜尋、業務服務
    //讓使用者很直接地對業務代表就可以使用到他想使用的業務服務

    public interface BusinessService
    {
        public void doProcess();
    }
    public class GetMoney : BusinessService
    {
        public void doProcess()
        {
            Console.WriteLn("Do Get Money");
        }
    }
    public class SaveMoney : BusinessService
    {
        public void doProcess()
        {
            Console.WriteLn("Do Save Money");
        }
    }
    public class BusinessLookup
    {
        public BusinessService GetBusinessService(string type)
        {
            return type == "Get" ? new GetMoney() : new SaveMoney();
        }
    }
    public class BusinessDelegate
    {
        private BusinessService businessService;
        private BusinessLookup businessLookup = new BusinessLookup();
        private string BusinessType;
        public void setBusinessType(string type)
        {
            this.BusinessType = type;
        }
        public void doTask()
        {
            businessService = businessLookup.GetBusinessService(this.BusinessType);
            businessService.doProcess();
        }
    }
    public class Client
    {
        private BusinessDelegate businessDelegate;
        public Client(BusinessDelegate bd)
        {
            this.businessDelegate = bd;
        }
        public void doTask(string aciton)
        {
            this.businessDelegate.setBusinessType(aciton);
            this.businessDelegate.doTask();
        }
    }
    public class BusinessDemo
    {
        public void Demo()
        {
            BusinessDelegate businessDelegate = new BusinessDelegate();
            Client client = new Client(businessDelegate);
            client.doTask("Get"); //Do Get Money
            client.doTask("Save");//Do Save Money
        }
    }
}

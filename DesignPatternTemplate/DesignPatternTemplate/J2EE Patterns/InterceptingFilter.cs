using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //攔截過濾器模式
    //我有一個程序想要執行
    //但在執行前我希望透過各種過濾確保狀態是可以執行的
    //或是在執行前可以執行一些額外的動作等等

    public interface Filter
    {
        public bool execute(string request);
    }
    public class LogFilter : Filter
    {
        public override bool execute(string request)
        {
            Console.WriteLn("Log Filter Record : ", request);
            return true;
        }
    }
    public class StateFilter : Filter
    {
        public override bool execute(string request)
        {
            if(request == "HOME")
                Console.WriteLn("State check : ", request, " Pass.");
            else
                Console.WriteLn("State check : ", request, " Failed.");
        }
    }
    public class Target
    {
        public void execute(string request)
        {
                Console.WriteLn("Do Target : ", request);
        }
    }
    public class FilterChain
    {
        private List<Filter> Filters = new List<Filter>();
        private Target target;
        public Filter(Target t)
        {
            this.target = t;
        }
        public void AddFilter(Filter f)
        {
            this.Filters.Add(f);
        }
        public void execute(string req)
        {
            foreach(Filter filter in Filters)
            {
                if(!filter.execute(req))
                    return;
            }
            target.execute(req);
        }
    }
    public class FilterManager
    {
        private FilterChain filterChain;
        public FilterManager(Target target)
        {
            filterChain = new FilterChain(target);
        }
        public void setFilter(Filter filter)
        {
            this.filterChain.AddFilter(filter);
        }
        public void Request(string req)
        {
            this.filterChain.execute(req);
        }
    }
    public class InterecptingFilterDemo
    {
        public void Demo()
        {
            FilterManager filterManager = new FilterManager(new Target());
            filterManager.setFilter(new StateFilter());
            filterManager.setFilter(new LogFilter());
            filterManager.Request("TEST");
            //State check : TEST Failed. then return here
            filterManager.Request("HOME");
            //State check : HOME Pass.
            //Log Filter Record : HOME.
            //Do Target : HOME.

        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TraderMarket.MenuService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MenuService.IMenuService")]
    public interface IMenuService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuService/GetMainMenus1", ReplyAction="http://tempuri.org/IMenuService/GetMainMenus1Response")]
        Commonlayer.Menu[] GetMainMenus1(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuService/GetMainMenus1", ReplyAction="http://tempuri.org/IMenuService/GetMainMenus1Response")]
        System.Threading.Tasks.Task<Commonlayer.Menu[]> GetMainMenus1Async(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuService/GetMainMenus2", ReplyAction="http://tempuri.org/IMenuService/GetMainMenus2Response")]
        Commonlayer.Menu[] GetMainMenus2(int roleID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuService/GetMainMenus2", ReplyAction="http://tempuri.org/IMenuService/GetMainMenus2Response")]
        System.Threading.Tasks.Task<Commonlayer.Menu[]> GetMainMenus2Async(int roleID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuService/GetSubMenus1", ReplyAction="http://tempuri.org/IMenuService/GetSubMenus1Response")]
        Commonlayer.Menu[] GetSubMenus1(string username, int parentID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuService/GetSubMenus1", ReplyAction="http://tempuri.org/IMenuService/GetSubMenus1Response")]
        System.Threading.Tasks.Task<Commonlayer.Menu[]> GetSubMenus1Async(string username, int parentID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuService/GetSubMenus2", ReplyAction="http://tempuri.org/IMenuService/GetSubMenus2Response")]
        Commonlayer.Menu[] GetSubMenus2(int roleID, int parentID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuService/GetSubMenus2", ReplyAction="http://tempuri.org/IMenuService/GetSubMenus2Response")]
        System.Threading.Tasks.Task<Commonlayer.Menu[]> GetSubMenus2Async(int roleID, int parentID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMenuServiceChannel : TraderMarket.MenuService.IMenuService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MenuServiceClient : System.ServiceModel.ClientBase<TraderMarket.MenuService.IMenuService>, TraderMarket.MenuService.IMenuService {
        
        public MenuServiceClient() {
        }
        
        public MenuServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MenuServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MenuServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MenuServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Commonlayer.Menu[] GetMainMenus1(string username) {
            return base.Channel.GetMainMenus1(username);
        }
        
        public System.Threading.Tasks.Task<Commonlayer.Menu[]> GetMainMenus1Async(string username) {
            return base.Channel.GetMainMenus1Async(username);
        }
        
        public Commonlayer.Menu[] GetMainMenus2(int roleID) {
            return base.Channel.GetMainMenus2(roleID);
        }
        
        public System.Threading.Tasks.Task<Commonlayer.Menu[]> GetMainMenus2Async(int roleID) {
            return base.Channel.GetMainMenus2Async(roleID);
        }
        
        public Commonlayer.Menu[] GetSubMenus1(string username, int parentID) {
            return base.Channel.GetSubMenus1(username, parentID);
        }
        
        public System.Threading.Tasks.Task<Commonlayer.Menu[]> GetSubMenus1Async(string username, int parentID) {
            return base.Channel.GetSubMenus1Async(username, parentID);
        }
        
        public Commonlayer.Menu[] GetSubMenus2(int roleID, int parentID) {
            return base.Channel.GetSubMenus2(roleID, parentID);
        }
        
        public System.Threading.Tasks.Task<Commonlayer.Menu[]> GetSubMenus2Async(int roleID, int parentID) {
            return base.Channel.GetSubMenus2Async(roleID, parentID);
        }
    }
}

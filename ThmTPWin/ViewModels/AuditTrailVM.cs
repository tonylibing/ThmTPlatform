﻿//-----------------------------------------------------------------------------
// File Name   : AuditTrailVM
// Author      : junlei
// Date        : 8/28/2020 6:16:34 PM
// Description : 
// Version     : 1.0.0      
// Updated     : 
//
//-----------------------------------------------------------------------------
using System.Collections.ObjectModel;
using System.Windows.Data;
using Prism.Mvvm;
using ThmCommon.Models;
using ThmTPWin.Models;

namespace ThmTPWin.ViewModels {
    internal class AuditTrailVM : BindableBase, IOrdersTabItm {
        public const string ID = "Audit Trail";
        public string Header => ID;
        public ObservableCollection<OrderAlgoDataView> OrderViewList { get; } = new();

        private readonly object _lock = new();
        public AuditTrailVM() {
            BindingOperations.EnableCollectionSynchronization(OrderViewList, _lock);
        }

        public void OnOrderDataUpdated(OrderData orderData) {
            if (OrderViewList.Count >= 100000) {
                OrderViewList.RemoveAt(OrderViewList.Count - 1);
            }

            OrderViewList.Insert(0, new OrderAlgoDataView(orderData));
        }
    }
}

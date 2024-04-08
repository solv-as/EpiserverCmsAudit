﻿using EPiServer.Data;
using EPiServer.Data.Dynamic;
using System;
using System.Linq;

namespace Solv.Optimizely.Cms.Audit.Models
{
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true)]
    public class PageTypeUsagesData : IDynamicData
    {
        public Identity Id
        {
            get; set;
        }

        public DateTime Seen { get; set; }

        public int ContentTypeId { get; set; }

        public string AuditJson { get; set; }

        public static PageTypeUsagesData Get(int contentTypeId)
        {
            var store = DynamicDataStoreFactory.Instance.CreateStore(typeof(PageTypeUsagesData));
            return store.Find<PageTypeUsagesData>("ContentTypeId", contentTypeId).FirstOrDefault();
        }

        public static void Save(PageTypeUsagesData pageTypeUsage)
        {
            var store = DynamicDataStoreFactory.Instance.CreateStore(typeof(PageTypeUsagesData));
            store.Save(pageTypeUsage);
        }

        public static void CleanUp()
        {
            var store = DynamicDataStoreFactory.Instance.CreateStore(typeof(PageTypeUsagesData));
            store.DeleteAll();
        }

    }
}

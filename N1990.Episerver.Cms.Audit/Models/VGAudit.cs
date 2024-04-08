﻿using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solv.Optimizely.Cms.Audit.Models
{
    public class VGAudit
    {
        #region Dynamic Properties

        public string UsagesSummary =>
            $"{PageCount} page(s), {BlockCount} block(s), {Usages.Count} properties";

        public string UsagesExpandButton => Usages.Count > 0
            ? "<button class=\"btn btn-xs btn-info\" onclick=\"toggleNextHiddenTr(this)\"><i class=\"glyphicon glyphicon-collapse-down\"></i></button>"
            : "";

        #endregion

        public string Name { get; set; }
        public int CriteriaCount { get; set; }
        public Guid Id { get; set; }
        public List<VisitorGroupUse> Usages{ get; set; }

        public int PageCount
        {
            get { return Usages.Where(u => u.ContentType == "Page").Count(); }
        }
        public int BlockCount
        {
            get { return Usages.Where(u => u.ContentType == "Block").Count(); }
        }

        public IEnumerable<ContentReference> ContentItems { get
            {
                return Usages.Select(vu => vu.Content).Distinct();
            }
        }

        public IEnumerable<string> PropertyNamesForUse(ContentReference cr)
        {
            return Usages.Where(u => u.Content == cr).Select(u => u.PropertyName);
        }


    }

    


}

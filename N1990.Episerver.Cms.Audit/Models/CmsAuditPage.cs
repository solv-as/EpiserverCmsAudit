using System;
using System.Collections.Generic;

namespace Solv.Optimizely.Cms.Audit.Models
{
	public class CmsAuditPage
	{
		public List<SiteAudit> Sites { get; set; }
        public List<ContentTypeAudit> ContentTypes { get; set; }

        public List<VGAudit>   VisitorGroups { get; set; }
        public DateTime JobLastRunTime { get; set; }

        public CmsAuditPage()
		{
			Sites = new List<SiteAudit>();
		}
	}
}
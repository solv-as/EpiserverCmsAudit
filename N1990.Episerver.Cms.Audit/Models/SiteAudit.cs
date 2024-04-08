using System.Collections.Generic;
using EPiServer.Web;

namespace Solv.Optimizely.Cms.Audit.Models
{
	public class SiteAudit
	{
		public SiteDefinition SiteDefo { get; set; }
		public List<ContentTypeAudit> ContentTypes { get; set; }

		public SiteAudit()
		{
			ContentTypes = new List<ContentTypeAudit>();
		}
	}
}
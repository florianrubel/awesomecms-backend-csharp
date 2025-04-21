using LibContent.Models.Page;
using LibUniversal.Constants;
using LibUniversal.Models.Entities.LocalizedRecursiveEntity;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibContent.Models.Entities.Page
{
    public class ViewPage : ViewLocalizedRecursiveEntity<ViewPage>
    {
        [SwaggerParameter(LibContent.Entities.Page.DOC_Title)]
        public string Title { get; set; }

        [SwaggerParameter(LibContent.Entities.Page.DOC_InternalTitle)]
        public string? InternalName { get; set; }

        [SwaggerParameter(LibContent.Entities.Page.DOC_NavigationTitle)]
        public string? NavigationTitle { get; set; }

        [SwaggerParameter(LibContent.Entities.Page.DOC_MetaDescription)]
        public string? MetaDescription { get; set; }

        [SwaggerParameter(LibContent.Entities.Page.DOC_MetaTags)]
        public Dictionary<string, MetaTag>? MetaTags { get; set; }

        [SwaggerParameter(LibContent.Entities.Page.DOC_IsRoot)]
        public bool IsRoot { get; set; } = false;

        [SwaggerParameter(LibContent.Entities.Page.DOC_Domain)]
        public string? Domain { get; set; }

        [SwaggerParameter(LibContent.Entities.Page.DOC_Slug)]
        [MinLength(1)]
        public string slug { get; set; }

        [SwaggerParameter(LibContent.Entities.Page.DOC_LockSlug)]
        public bool LockSlug { get; set; }

        [SwaggerParameter(LibContent.Entities.Page.DOC_InheritMetaTagsFromParent)]
        public bool InheritMetaTagsFromParent { get; set; }
    }
}

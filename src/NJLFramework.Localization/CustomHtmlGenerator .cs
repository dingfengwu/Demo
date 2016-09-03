using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NJLFramework.Localization
{
    /// <summary>
    /// 重写默认的HTML生成器，
    /// 使ViewModel上的Display的Name值从资源文件中获取
    /// </summary>
    public class CustomHtmlGenerator : DefaultHtmlGenerator
    {
        IStringLocalizerFactory _stringLocalizerFactory;

        public CustomHtmlGenerator(IAntiforgery antiforgery, 
            IOptions<MvcViewOptions> optionsAccessor, 
            IModelMetadataProvider metadataProvider, 
            IUrlHelperFactory urlHelperFactory, 
            HtmlEncoder htmlEncoder, 
            ClientValidatorCache clientValidatorCache,
            IStringLocalizerFactory stringLocalizerFactory
            ) : 
            base(antiforgery, 
                optionsAccessor, 
                metadataProvider, 
                urlHelperFactory, 
                htmlEncoder, 
                clientValidatorCache)
        {
            _stringLocalizerFactory = stringLocalizerFactory;
        }

        public override TagBuilder GenerateLabel(ViewContext viewContext, ModelExplorer modelExplorer, string expression, string labelText, object htmlAttributes)
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException(nameof(viewContext));
            }

            if (modelExplorer == null)
            {
                throw new ArgumentNullException(nameof(modelExplorer));
            }

            var resolvedLabelText = GetLabelText(labelText, modelExplorer);

            if (string.IsNullOrEmpty(resolvedLabelText))
            {
                return null;
            }

            var tagBuilder = new TagBuilder("label");
            var idString =
                TagBuilder.CreateSanitizedId(GetFullHtmlFieldName(viewContext, expression), IdAttributeDotReplacement);
            tagBuilder.Attributes.Add("for", idString);
            tagBuilder.InnerHtml.Clear();
            tagBuilder.InnerHtml.Append(resolvedLabelText);
            tagBuilder.MergeAttributes(GetHtmlAttributeDictionaryOrNull(htmlAttributes), replaceExisting: true);

            return tagBuilder;
        }

        private string GetLabelText(string labelText,ModelExplorer modelExplorer)
        {
            var resouceName= labelText ??
                 modelExplorer.Metadata.DisplayName ??
                 modelExplorer.Metadata.PropertyName;

            if (resouceName == null)
            {
                resouceName = $"{modelExplorer.Metadata.ContainerType.ToString()}.{modelExplorer.Metadata.PropertyName}";
            }
            
            var modelType = modelExplorer.Container.ModelType;
            var resolvedLabelText = _stringLocalizerFactory.Create(modelType).GetString(resouceName)?.Value;
            if (string.IsNullOrWhiteSpace(resolvedLabelText))
            {
                resolvedLabelText = resouceName.Split('.').Last();
            }
            return resolvedLabelText;
        }

        public override TagBuilder GenerateTextBox(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, string format, object htmlAttributes)
        {
            var tagBuilder=base.GenerateTextBox(viewContext, modelExplorer, expression, value, format, htmlAttributes);

            return tagBuilder;
        }

        internal static string GetFullHtmlFieldName(ViewContext viewContext, string expression)
        {
            var fullName = viewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);
            return fullName;
        }


        // Only need a dictionary if htmlAttributes is non-null. TagBuilder.MergeAttributes() is fine with null.
        private static IDictionary<string, object> GetHtmlAttributeDictionaryOrNull(object htmlAttributes)
        {
            IDictionary<string, object> htmlAttributeDictionary = null;
            if (htmlAttributes != null)
            {
                htmlAttributeDictionary = htmlAttributes as IDictionary<string, object>;
                if (htmlAttributeDictionary == null)
                {
                    htmlAttributeDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                }
            }

            return htmlAttributeDictionary;
        }
    }
}

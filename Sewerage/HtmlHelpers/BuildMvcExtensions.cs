using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Build.Mvc;
using Build.Mvc.Html;

namespace Sewerage.HtmlHelpers
{
    public static class BuildMvcExtensions
    {
        public static IHtmlTagBuilder BuildTh(this HtmlHelper htmlHelper, string property = null)
        {
            var tag = htmlHelper.BuildTag("th");
            return (property == null)
                       ? tag
                       : tag.With(x => x.InternalBuilder.InnerHtml += property);
        }

        public static IHtmlTagBuilder BuildThFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var property = metadata.DisplayName ?? metadata.PropertyName;

            return htmlHelper.BuildTh(property);
        }

        public static IHtmlTagBuilder BuildTd(this HtmlHelper htmlHelper)
        {
            return htmlHelper.BuildTag("td");
        }

        public static IHtmlTagBuilder BuildDiv(this HtmlHelper htmlHelper)
        {
            return htmlHelper.BuildTag("div");
        }

        public static IHtmlTagBuilder BuildSubmitButtonWithIcon(this HtmlHelper htmlHelper, string text, string icon)
        {
            return htmlHelper.BuildTag("button").With(x =>
            {
                x.Attr("type", "submit");
                x.InternalBuilder.InnerHtml += htmlHelper.BuildTag("i").AddClass(icon).ToHtmlString();
                x.InternalBuilder.InnerHtml += AppendLeadingSpace(text);
            });
        }

        public static IHtmlTagBuilder BuildLinkWithIcon(this HtmlHelper htmlHelper, string text, string href, string icon)
        {
            return htmlHelper.BuildTag("a").With(x =>
                                                     {
                                                         x.Href(href);
                                                         x.InternalBuilder.InnerHtml += htmlHelper.BuildTag("i").AddClass(icon).ToHtmlString();
                                                         x.InternalBuilder.InnerHtml += AppendLeadingSpace(text);
                                                     });
        }

        public static IHtmlTagBuilder BuildControlGroup(this HtmlHelper htmlHelper, string property, string dataTypeName = null)
        {
            return htmlHelper.BuildDiv().With(x =>
            {
                x.AddClass("control-group");
                x.InternalBuilder.InnerHtml += htmlHelper.BuildLabel(property).AddClass("control-label").ToHtmlString();
                x.InternalBuilder.InnerHtml += htmlHelper.BuildDiv().With(y =>
                {
                    y.AddClass("controls");
                    switch (dataTypeName)
                    {
                        case "MultilineText":
                            y.InternalBuilder.InnerHtml += htmlHelper.BuildTextArea(property).Bind("value", property).AddClass("input-medium").Attr("rows", 3).ToHtmlString();
                            break;
                        case "Password":
                            y.InternalBuilder.InnerHtml += htmlHelper.BuildPassword(property).Bind("value", property).AddClass("input-medium").ToHtmlString();
                            break;
                        default:
                            y.InternalBuilder.InnerHtml += htmlHelper.BuildTextBox(property).Bind("value", property).AddClass("input-medium").ToHtmlString();
                            break;
                    }
                    y.InternalBuilder.InnerHtml += htmlHelper.BuildValidationMessage(property).AddClass("help-inline").ToHtmlString();
                });
            });
        }

        public static IHtmlTagBuilder BuildControlGroupCheckbox(this HtmlHelper htmlHelper, string property)
        {
            return htmlHelper.BuildDiv().With(x =>
            {
                x.AddClass("control-group");
                x.InternalBuilder.InnerHtml += htmlHelper.BuildLabel(property).AddClass("control-label").ToHtmlString();
                x.InternalBuilder.InnerHtml += htmlHelper.BuildDiv().With(y =>
                {
                    y.AddClass("controls");
                    y.InternalBuilder.InnerHtml += htmlHelper.BuildCheckBox(property).Bind("checked", property).AddClass("input-medium").ToHtmlString();
                    y.InternalBuilder.InnerHtml += htmlHelper.BuildValidationMessage(property).AddClass("help-inline").ToHtmlString();
                });
            });
        }

        public static IHtmlTagBuilder BuildControlGroupFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var property = metadata.PropertyName;
            var dataTypeName = metadata.DataTypeName;
            var type = metadata.ModelType.FullName;

            var boolFullName = typeof(Boolean).FullName;

            return type == boolFullName
                       ? htmlHelper.BuildControlGroupCheckbox(property)
                       : htmlHelper.BuildControlGroup(property, dataTypeName);
        }

        public static IHtmlTagBuilder BuildFormActions(this HtmlHelper htmlHelper, string deleteAction)
        {
            return htmlHelper.BuildDiv().With(x =>
            {
                x.AddClass("form-actions");
                x.InternalBuilder.InnerHtml += htmlHelper.BuildSubmitButtonWithIcon("Save changes", "icon-ok icon-white").Bind("enable", "IsUpdated() || IsAdded()").AddClass("btn").AddClass("btn-primary").ToHtmlString();
                x.InternalBuilder.InnerHtml += AppendLeadingSpace(htmlHelper.BuildLinkWithIcon("Delete", "#", "icon-trash icon-white").AddClass("btn").AddClass("btn-danger").Bind("visible", "CanDelete").Bind("click", deleteAction).ToHtmlString());
                x.InternalBuilder.InnerHtml += AppendLeadingSpace(htmlHelper.BuildLinkWithIcon("Back", "#", "icon-arrow-left").AddClass("btn").Bind("click", "$parent.showDefaultView").ToHtmlString());
                x.InternalBuilder.InnerHtml += AppendLeadingSpace(htmlHelper.BuildLinkWithIcon("Undo changes", "#", "icon-remove").AddClass("btn").Bind("visible", "IsUpdated").Bind("click", "$parent.revertSections").ToHtmlString());

            });
        }

        private static string AppendLeadingSpace(string text)
        {
            return string.Format(" {0}", text);
        }
    }
}
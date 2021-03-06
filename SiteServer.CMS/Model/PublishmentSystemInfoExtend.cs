﻿using System;
using System.Globalization;
using BaiRong.Core;
using BaiRong.Core.Model;
using BaiRong.Core.Model.Enumerations;

namespace SiteServer.CMS.Model
{
    [Serializable]
    public class PublishmentSystemInfoExtend : ExtendedAttributes
    {
        public const string DefaultApiUrl = "/api";
        public const string DefaultHomeUrl = "/home";

        private readonly string _publishmentSystemDir;

        public PublishmentSystemInfoExtend(string publishmentSystemDir, string settingsXml)
        {
            _publishmentSystemDir = publishmentSystemDir;
            Load(settingsXml);
        }

        /****************站点设置********************/

        public string Charset
        {
            get { return GetString("Charset", ECharsetUtils.GetValue(ECharset.utf_8)); }
            set { Set("Charset", value); }
        }

        public int PageSize
        {
            get { return GetInt("PageSize", 30); }
            set { Set("PageSize", value.ToString()); }
        }

        //public EVisualType VisualType
        //{
        //    get
        //    {
        //        EVisualType visualType = EVisualTypeUtils.GetEnumType(base.GetString("VisualType", EVisualTypeUtils.GetValue(EVisualType.Static)));
        //        if (visualType != EVisualType.Static && visualType != EVisualType.Dynamic)
        //        {
        //            visualType = EVisualType.Static;
        //        }
        //        return visualType;
        //    }
        //    set { base.Set("VisualType", EVisualTypeUtils.GetValue(value)); }
        //}

        public bool IsCountDownload
        {
            get { return GetBool("IsCountDownload", true); }
            set { Set("IsCountDownload", value.ToString()); }
        }

        public bool IsCountHits
        {
            get { return GetBool("IsCountHits"); }
            set { Set("IsCountHits", value.ToString()); }
        }

        public bool IsCountHitsByDay
        {
            get { return GetBool("IsCountHitsByDay"); }
            set { Set("IsCountHitsByDay", value.ToString()); }
        }

        public bool IsGroupContent
        {
            get { return GetBool("IsGroupContent", true); }
            set { Set("IsGroupContent", value.ToString()); }
        }

        public bool IsRelatedByTags
        {
            get { return GetBool("IsRelatedByTags", true); }
            set { Set("IsRelatedByTags", value.ToString()); }
        }

        public bool IsTranslate
        {
            get { return GetBool("IsTranslate", true); }
            set { Set("IsTranslate", value.ToString()); }
        }

        public bool IsSaveImageInTextEditor
        {
            get { return GetBool("IsSaveImageInTextEditor", true); }
            set { Set("IsSaveImageInTextEditor", value.ToString()); }
        }

        public bool IsAutoPageInTextEditor
        {
            get { return GetBool("IsAutoPageInTextEditor"); }
            set { Set("IsAutoPageInTextEditor", value.ToString()); }
        }

        public int AutoPageWordNum
        {
            get { return GetInt("AutoPageWordNum", 1500); }
            set { Set("AutoPageWordNum", value.ToString()); }
        }

        public bool IsContentTitleBreakLine
        {
            get { return GetBool("IsContentTitleBreakLine"); }
            set { Set("IsContentTitleBreakLine", value.ToString()); }
        }

        /// <summary>
        /// 敏感词自动检测
        /// </summary>
        public bool IsAutoCheckKeywords
        {
            get { return GetBool("lIsAutoCheckKeywords"); }
            set { Set("lIsAutoCheckKeywords", value.ToString()); }
        }

        public int PhotoSmallWidth
        {
            get { return GetInt("PhotoSmallWidth", 70); }
            set { Set("PhotoSmallWidth", value.ToString()); }
        }

        public int PhotoMiddleWidth
        {
            get { return GetInt("PhotoMiddleWidth", 400); }
            set { Set("PhotoMiddleWidth", value.ToString()); }
        }

        /****************图片水印设置********************/

        public bool IsWaterMark
        {
            get { return GetBool("IsWaterMark"); }
            set { Set("IsWaterMark", value.ToString()); }
        }

        public bool IsImageWaterMark
        {
            get { return GetBool("IsImageWaterMark"); }
            set { Set("IsImageWaterMark", value.ToString()); }
        }

        public int WaterMarkPosition
        {
            get { return GetInt("WaterMarkPosition", 9); }
            set { Set("WaterMarkPosition", value.ToString()); }
        }

        public int WaterMarkTransparency
        {
            get { return GetInt("WaterMarkTransparency", 5); }
            set { Set("WaterMarkTransparency", value.ToString()); }
        }

        public int WaterMarkMinWidth
        {
            get { return GetInt("WaterMarkMinWidth", 200); }
            set { Set("WaterMarkMinWidth", value.ToString()); }
        }

        public int WaterMarkMinHeight
        {
            get { return GetInt("WaterMarkMinHeight", 200); }
            set { Set("WaterMarkMinHeight", value.ToString()); }
        }

        public string WaterMarkFormatString
        {
            get { return GetString("WaterMarkFormatString", string.Empty); }
            set { Set("WaterMarkFormatString", value); }
        }

        public string WaterMarkFontName
        {
            get { return GetString("WaterMarkFontName", string.Empty); }
            set { Set("WaterMarkFontName", value); }
        }

        public int WaterMarkFontSize
        {
            get { return GetInt("WaterMarkFontSize", 12); }
            set { Set("WaterMarkFontSize", value.ToString()); }
        }

        public string WaterMarkImagePath
        {
            get { return GetString("WaterMarkImagePath", string.Empty); }
            set { Set("WaterMarkImagePath", value); }
        }

        /****************生成页面设置********************/

        public bool IsSeparatedWeb
        {
            get { return GetBool("IsSeparatedWeb"); }
            set { Set("IsSeparatedWeb", value.ToString()); }
        }

        public string SeparatedWebUrl
        {
            get { return GetString("SeparatedWebUrl"); }
            set { Set("SeparatedWebUrl", value); }
        }

        public string WebUrl => IsSeparatedWeb ? SeparatedWebUrl : PageUtils.ParseNavigationUrl($"~/{_publishmentSystemDir}");

        public bool IsSeparatedAssets
        {
            get { return GetBool("IsSeparatedAssets"); }
            set { Set("IsSeparatedAssets", value.ToString()); }
        }

        public string SeparatedAssetsUrl
        {
            get { return GetString("SeparatedAssetsUrl"); }
            set { Set("SeparatedAssetsUrl", value); }
        }

        public string AssetsDir
        {
            get { return GetString("AssetsDir", "upload"); }
            set { Set("AssetsDir", value); }
        }

        public string AssetsUrl => IsSeparatedAssets ? SeparatedAssetsUrl : PageUtils.ParseNavigationUrl($"~/{_publishmentSystemDir}/{AssetsDir}/");

        public string ChannelFilePathRule
        {
            get { return GetString("ChannelFilePathRule", "/channels/{@ChannelID}.html"); }
            set { Set("ChannelFilePathRule", value); }
        }

        public string ContentFilePathRule
        {
            get { return GetString("ContentFilePathRule", "/contents/{@ChannelID}/{@ContentID}.html"); }
            set { Set("ContentFilePathRule", value); }
        }

        public bool IsCreateContentIfContentChanged
        {
            get { return GetBool("IsCreateContentIfContentChanged", true); }
            set { Set("IsCreateContentIfContentChanged", value.ToString()); }
        }

        public bool IsCreateChannelIfChannelChanged
        {
            get { return GetBool("IsCreateChannelIfChannelChanged", true); }
            set { Set("IsCreateChannelIfChannelChanged", value.ToString()); }
        }

        public bool IsCreateShowPageInfo
        {
            get { return GetBool("IsCreateShowPageInfo"); }
            set { Set("IsCreateShowPageInfo", value.ToString()); }
        }

        public bool IsCreateIe8Compatible
        {
            get { return GetBool("IsCreateIe8Compatible"); }
            set { Set("IsCreateIe8Compatible", value.ToString()); }
        }

        public bool IsCreateBrowserNoCache
        {
            get { return GetBool("IsCreateBrowserNoCache"); }
            set { Set("IsCreateBrowserNoCache", value.ToString()); }
        }

        public bool IsCreateJsIgnoreError
        {
            get { return GetBool("IsCreateJsIgnoreError"); }
            set { Set("IsCreateJsIgnoreError", value.ToString()); }
        }

        public bool IsCreateSearchDuplicate
        {
            get { return GetBool("IsCreateSearchDuplicate", true); }
            set { Set("IsCreateSearchDuplicate", value.ToString()); }
        }

        public bool IsCreateWithJQuery
        {
            get { return GetBool("IsCreateWithJQuery", true); }
            set { Set("IsCreateWithJQuery", value.ToString()); }
        }

        public bool IsCreateDoubleClick
        {
            get { return GetBool("IsCreateDoubleClick"); }
            set { Set("IsCreateDoubleClick", value.ToString()); }
        }

        public int CreateStaticMaxPage
        {
            get { return GetInt("CreateStaticMaxPage", 10); }
            set { Set("CreateStaticMaxPage", value.ToString()); }
        }

        public bool IsCreateStaticContentByAddDate
        {
            get { return GetBool("IsCreateStaticContentByAddDate"); }
            set { Set("IsCreateStaticContentByAddDate", value.ToString()); }
        }

        public DateTime CreateStaticContentAddDate
        {
            get { return GetDateTime("CreateStaticContentAddDate", DateTime.MinValue); }
            set { Set("CreateStaticContentAddDate", DateUtils.GetDateString(value)); }
        }

        public bool IsCreateMultiThread
        {
            get { return GetBool("IsCreateMultiThread"); }
            set { Set("IsCreateMultiThread", value.ToString()); }
        }

        /****************流量统计设置********************/

        public bool IsTracker
        {
            get { return GetBool("IsTracker"); }
            set { Set("IsTracker", value.ToString()); }
        }

        public int TrackerDays
        {
            get { return GetInt("TrackerDays"); }
            set { Set("TrackerDays", value.ToString()); }
        }

        public int TrackerPageView
        {
            get { return GetInt("TrackerPageView"); }
            set { Set("TrackerPageView", value.ToString()); }
        }

        public int TrackerUniqueVisitor
        {
            get { return GetInt("TrackerUniqueVisitor"); }
            set { Set("TrackerUniqueVisitor", value.ToString()); }
        }

        public int TrackerCurrentMinute
        {
            get { return GetInt("TrackerCurrentMinute", 30); }
            set { Set("TrackerCurrentMinute", value.ToString()); }
        }

        /****************显示项设置********************/

        public string ChannelDisplayAttributes
        {
            get { return GetString("ChannelDisplayAttributes", string.Empty); }
            set { Set("ChannelDisplayAttributes", value); }
        }

        public string ChannelEditAttributes
        {
            get { return GetString("ChannelEditAttributes", string.Empty); }
            set { Set("ChannelEditAttributes", value); }
        }

        /****************跨站转发设置********************/

        public bool IsCrossSiteTransChecked
        {
            get { return GetBool("IsCrossSiteTransChecked"); }
            set { Set("IsCrossSiteTransChecked", value.ToString()); }
        }

        /****************站内链接设置********************/

        public bool IsInnerLink
        {
            get { return GetBool("IsInnerLink"); }
            set { Set("IsInnerLink", value.ToString()); }
        }

        public bool IsInnerLinkByChannelName
        {
            get { return GetBool("IsInnerLinkByChannelName"); }
            set { Set("IsInnerLinkByChannelName", value.ToString()); }
        }

        public string InnerLinkFormatString
        {
            get { return GetString("InnerLinkFormatString", @"<a href=""{0}"" target=""_blank"">{1}</a>"); }
            set { Set("InnerLinkFormatString", value); }
        }

        public int InnerLinkMaxNum
        {
            get { return GetInt("InnerLinkMaxNum", 10); }
            set { Set("InnerLinkMaxNum", value.ToString()); }
        }

        /****************记录系统操作设置********************/

        public bool ConfigTemplateIsCodeMirror
        {
            get { return GetBool("ConfigTemplateIsCodeMirror", true); }
            set { Set("ConfigTemplateIsCodeMirror", value.ToString()); }
        }

        public int ConfigVideoContentInsertWidth
        {
            get { return GetInt("ConfigVideoContentInsertWidth", 420); }
            set { Set("ConfigVideoContentInsertWidth", value.ToString()); }
        }

        public int ConfigVideoContentInsertHeight
        {
            get { return GetInt("ConfigVideoContentInsertHeight", 280); }
            set { Set("ConfigVideoContentInsertHeight", value.ToString()); }
        }

        public string ConfigExportType
        {
            get { return GetString("ConfigExportType", string.Empty); }
            set { Set("ConfigExportType", value); }
        }

        public string ConfigExportPeriods
        {
            get { return GetString("ConfigExportPeriods", string.Empty); }
            set { Set("ConfigExportPeriods", value); }
        }

        public string ConfigExportDisplayAttributes
        {
            get { return GetString("ConfigExportDisplayAttributes", string.Empty); }
            set { Set("ConfigExportDisplayAttributes", value); }
        }

        public string ConfigExportIsChecked
        {
            get { return GetString("ConfigExportIsChecked", string.Empty); }
            set { Set("ConfigExportIsChecked", value); }
        }

        public string ConfigSelectImageCurrentUrl
        {
            get { return GetString("ConfigSelectImageCurrentUrl", "@/" + ImageUploadDirectoryName); }
            set { Set("ConfigSelectImageCurrentUrl", value); }
        }

        public string ConfigSelectVideoCurrentUrl
        {
            get { return GetString("ConfigSelectVideoCurrentUrl", "@/" + VideoUploadDirectoryName); }
            set { Set("ConfigSelectVideoCurrentUrl", value); }
        }

        public string ConfigSelectFileCurrentUrl
        {
            get { return GetString("ConfigSelectFileCurrentUrl", "@/" + FileUploadDirectoryName); }
            set { Set("ConfigSelectFileCurrentUrl", value); }
        }

        public string ConfigUploadImageIsTitleImage
        {
            get { return GetString("ConfigUploadImageIsTitleImage", "True"); }
            set { Set("ConfigUploadImageIsTitleImage", value); }
        }

        public string ConfigUploadImageTitleImageWidth
        {
            get { return GetString("ConfigUploadImageTitleImageWidth", "300"); }
            set { Set("ConfigUploadImageTitleImageWidth", value); }
        }

        public string ConfigUploadImageTitleImageHeight
        {
            get { return GetString("ConfigUploadImageTitleImageHeight", string.Empty); }
            set { Set("ConfigUploadImageTitleImageHeight", value); }
        }

        public string ConfigUploadImageIsShowImageInTextEditor
        {
            get { return GetString("ConfigUploadImageIsShowImageInTextEditor", "True"); }
            set { Set("ConfigUploadImageIsShowImageInTextEditor", value); }
        }

        public string ConfigUploadImageIsLinkToOriginal
        {
            get { return GetString("ConfigUploadImageIsLinkToOriginal", string.Empty); }
            set { Set("ConfigUploadImageIsLinkToOriginal", value); }
        }

        public string ConfigUploadImageIsSmallImage
        {
            get { return GetString("ConfigUploadImageIsSmallImage", "True"); }
            set { Set("ConfigUploadImageIsSmallImage", value); }
        }

        public string ConfigUploadImageSmallImageWidth
        {
            get { return GetString("ConfigUploadImageSmallImageWidth", "500"); }
            set { Set("ConfigUploadImageSmallImageWidth", value); }
        }

        public string ConfigUploadImageSmallImageHeight
        {
            get { return GetString("ConfigUploadImageSmallImageHeight", string.Empty); }
            set { Set("ConfigUploadImageSmallImageHeight", value); }
        }

        /****************评论设置********************/

        public bool IsCommentable
        {
            get { return GetBool("IsCommentable", true); }
            set { Set("IsCommentable", value.ToString()); }
        }

        public bool IsCheckComments
        {
            get { return GetBool("IsCheckComments"); }
            set { Set("IsCheckComments", value.ToString()); }
        }

        public bool IsAnonymousComments
        {
            get { return GetBool("IsAnonymousComments", true); }
            set { Set("IsAnonymousComments", value.ToString()); }
        }

        /****************站点基本设置********************/
        public string SiteSettingsCollection
        {
            get { return GetString("SiteSettingsCollection", string.Empty); }
            set { Set("SiteSettingsCollection", value); }
        }

        #region 上传设置

        public string ImageUploadDirectoryName
        {
            get { return GetString("ImageUploadDirectoryName", "upload/images"); }
            set { Set("ImageUploadDirectoryName", value); }
        }

        public string ImageUploadDateFormatString
        {
            get { return GetString("ImageUploadDateFormatString", EDateFormatTypeUtils.GetValue(EDateFormatType.Month)); }
            set { Set("ImageUploadDateFormatString", value); }
        }

        public bool IsImageUploadChangeFileName
        {
            get { return GetBool("IsImageUploadChangeFileName", true); }
            set { Set("IsImageUploadChangeFileName", value.ToString()); }
        }

        public string ImageUploadTypeCollection
        {
            get { return GetString("ImageUploadTypeCollection", "gif|jpg|jpeg|bmp|png|pneg|swf"); }
            set { Set("ImageUploadTypeCollection", value); }
        }

        public int ImageUploadTypeMaxSize
        {
            get { return GetInt("ImageUploadTypeMaxSize", 15360); }
            set { Set("ImageUploadTypeMaxSize", value.ToString()); }
        }

        public string VideoUploadDirectoryName
        {
            get { return GetString("VideoUploadDirectoryName", "upload/videos"); }
            set { Set("VideoUploadDirectoryName", value); }
        }

        public string VideoUploadDateFormatString
        {
            get { return GetString("VideoUploadDateFormatString", EDateFormatTypeUtils.GetValue(EDateFormatType.Month)); }
            set { Set("VideoUploadDateFormatString", value); }
        }

        public bool IsVideoUploadChangeFileName
        {
            get { return GetBool("IsVideoUploadChangeFileName", true); }
            set { Set("IsVideoUploadChangeFileName", value.ToString()); }
        }

        public string VideoUploadTypeCollection
        {
            get { return GetString("VideoUploadTypeCollection", "asf|asx|avi|flv|mid|midi|mov|mp3|mp4|mpg|mpeg|ogg|ra|rm|rmb|rmvb|rp|rt|smi|swf|wav|webm|wma|wmv|viv"); }
            set { Set("VideoUploadTypeCollection", value); }
        }

        public int VideoUploadTypeMaxSize
        {
            get { return GetInt("VideoUploadTypeMaxSize", 307200); }
            set { Set("VideoUploadTypeMaxSize", value.ToString()); }
        }

        public string FileUploadDirectoryName
        {
            get { return GetString("FileUploadDirectoryName", "upload/files"); }
            set { Set("FileUploadDirectoryName", value); }
        }

        public string FileUploadDateFormatString
        {
            get { return GetString("FileUploadDateFormatString", EDateFormatTypeUtils.GetValue(EDateFormatType.Month)); }
            set { Set("FileUploadDateFormatString", value); }
        }

        public bool IsFileUploadChangeFileName
        {
            get { return GetBool("IsFileUploadChangeFileName", true); }
            set { Set("IsFileUploadChangeFileName", value.ToString()); }
        }

        public string FileUploadTypeCollection
        {
            get { return GetString("FileUploadTypeCollection", "zip,rar,7z,js,css,txt,doc,docx,ppt,pptx,xls,xlsx,pdf"); }
            set { Set("FileUploadTypeCollection", value); }
        }

        public int FileUploadTypeMaxSize
        {
            get { return GetInt("FileUploadTypeMaxSize", 307200); }
            set { Set("FileUploadTypeMaxSize", value.ToString()); }
        }

        #endregion

        #region weixin

        public bool WxIsWebMenu
        {
            get { return GetBool("WxIsWebMenu"); }
            set { Set("WxIsWebMenu", value.ToString()); }
        }

        public string WxWebMenuType
        {
            get { return GetString("WxWebMenuType", "Type1"); }
            set { Set("WxWebMenuType", value); }
        }

        public string WxWebMenuColor
        {
            get { return GetString("WxWebMenuColor", "41C281"); }
            set { Set("WxWebMenuColor", value); }
        }

        public bool WxIsWebMenuLeft
        {
            get { return GetBool("WxIsWebMenuLeft", true); }
            set { Set("WxIsWebMenuLeft", value.ToString()); }
        }

        public bool WxCardIsClaimCardCredits
        {
            get { return GetBool("WxCardIsClaimCardCredits"); }
            set { Set("WxCardIsClaimCardCredits", value.ToString()); }
        }

        public int WxCardClaimCardCredits
        {
            get { return GetInt("WxCardClaimCardCredits", 20); }
            set { Set("WxCardClaimCardCredits", value.ToString()); }
        }

        public bool WxCardIsGiveConsumeCredits
        {
            get { return GetBool("WxCardIsGiveConsumeCredits"); }
            set { Set("WxCardIsGiveConsumeCredits", value.ToString()); }
        }

        public decimal WxCardConsumeAmount
        {
            get { return GetDecimal("WxCardConsumeAmount", 100); }
            set { Set("WxCardConsumeAmount", value.ToString(CultureInfo.InvariantCulture)); }
        }

        public int WxCardGiveCredits
        {
            get { return GetInt("WxCardGiveCredits", 50); }
            set { Set("WxCardGiveCredits", value.ToString()); }
        }

        public bool WxCardIsBinding
        {
            get { return GetBool("WxCardIsBinding", true); }
            set { Set("WxCardIsBinding", value.ToString()); }
        }

        public bool WxCardIsExchange
        {
            get { return GetBool("WxCardIsExchange", true); }
            set { Set("WxCardIsExchange", value.ToString()); }
        }

        public decimal WxCardExchangeProportion
        {
            get { return GetDecimal("WxCardExchangeProportion", 10); }
            set { Set("WxCardExchangeProportion", value.ToString(CultureInfo.InvariantCulture)); }
        }

        public bool WxCardIsSign
        {
            get { return GetBool("WxCardIsSign"); }
            set { Set("WxCardIsSign", value.ToString()); }
        }

        public string WxCardSignCreditsConfigure
        {
            get { return GetString("WxCardSignCreditsConfigure", string.Empty); }
            set { Set("WxCardSignCreditsConfigure", value); }
        }

        #endregion
    }
}

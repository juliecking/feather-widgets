﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feather.Widgets.TestUI.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FeatherWidgets.TestUI.TestCases.Forms.FileUpload
{
    /// <summary>
    /// ChangeFileUploadTemplate test class.
    /// </summary>
    [TestClass]
    public class ChangeFileUploadTemplate_ : FeatherTestCase
    {
        /// <summary>
        /// UI test ChangeFileUploadTemplate
        /// </summary>
        [TestMethod,
        Owner(FeatherTeams.SitefinityTeam6),
        TestCategory(FeatherTestCategories.Bootstrap),
        TestCategory(FeatherTestCategories.Forms)]
        public void ChangeFileUploadTemplate()
        {
            BAT.Macros().NavigateTo().Modules().Forms(this.Culture);
            BAT.Wrappers().Backend().Forms().FormsDashboard().OpenFormFromTheGrid(FormName);
            BATFeather.Wrappers().Backend().Pages().PageZoneEditorWrapper().EditWidget(FileFieldController);
            BATFeather.Wrappers().Backend().Navigation().NavigationWidgetEditWrapper().MoreOptions();
            BATFeather.Wrappers().Backend().Forms().FormsContentScreenWrapper().SelectNewTemplate(TemplateNameFile);
            BATFeather.Wrappers().Backend().ContentBlocks().ContentBlocksWrapper().SaveChanges();
            BATFeather.Wrappers().Backend().Forms().FormsContentScreenWrapper().WaitForFieldContent(TemplateContentFile, FileFieldController);
            BAT.Wrappers().Backend().Pages().PageZoneEditorWrapper().CheckWidgetContent(FileFieldController, TemplateContentFile);         
            BAT.Wrappers().Backend().Forms().FormsContentScreen().PublishForm();
            BAT.Macros().NavigateTo().CustomPage("~/" + PageName.ToLower(), true, this.Culture);
            Assert.IsTrue(BAT.Wrappers().Frontend().Pages().PagesWrapperFrontend().GetPageContent().InnerText.Contains(TemplateContentFile), "Template is not presented");

            BAT.Macros().NavigateTo().Design().WidgetTemplates();
            BATFeather.Wrappers().Backend().WidgetTemplates().WidgetTemplatesWrapper().CreateTemplate();
            BATFeather.Wrappers().Backend().WidgetTemplates().WidgetTemplatesCreateScreenFrameWrapper().SelectTemplate("FileField (MVC)");
            BATFeather.Wrappers().Backend().WidgetTemplates().WidgetTemplatesCreateScreenFrameWrapper().EnterTextInTextArea(TemplateContent);
            BATFeather.Wrappers().Backend().WidgetTemplates().WidgetTemplatesCreateScreenFrameWrapper().EnterWidgetTemplateName(TemplateName);
            BATFeather.Wrappers().Backend().WidgetTemplates().WidgetTemplatesCreateScreenFrameWrapper().CreateThisTemplate();
            BAT.Macros().NavigateTo().Modules().Forms(this.Culture);
            BAT.Wrappers().Backend().Forms().FormsDashboard().OpenFormFromTheGrid(FormName);
            BATFeather.Wrappers().Backend().Pages().PageZoneEditorWrapper().EditWidget(FileFieldController);
            BATFeather.Wrappers().Backend().Navigation().NavigationWidgetEditWrapper().MoreOptions();
            BATFeather.Wrappers().Backend().Forms().FormsContentScreenWrapper().SelectNewTemplate(TemplateNameNew);
            BATFeather.Wrappers().Backend().ContentBlocks().ContentBlocksWrapper().SaveChanges();
            BATFeather.Wrappers().Backend().Forms().FormsContentScreenWrapper().WaitForFieldContent(TemplateContent, FileFieldController);
            BAT.Wrappers().Backend().Pages().PageZoneEditorWrapper().CheckWidgetContent(FileFieldController, TemplateContent);     
            BAT.Wrappers().Backend().Forms().FormsContentScreen().PublishForm();
            BAT.Macros().NavigateTo().CustomPage("~/" + PageName.ToLower(), true, this.Culture);
            Assert.IsTrue(BAT.Wrappers().Frontend().Pages().PagesWrapperFrontend().GetPageContent().InnerText.Contains(TemplateContent), "Template is not presented");
        }

        /// <summary>
        /// Performs Server Setup and prepare the system with needed data.
        /// </summary>
        protected override void ServerSetup()
        {
            BAT.Macros().User().EnsureAdminLoggedIn();
            BAT.Arrange(this.TestName).ExecuteSetUp();
        }

        /// <summary>
        /// Performs clean up and clears all data created by the test.
        /// </summary>
        protected override void ServerCleanup()
        {
            BAT.Arrange(this.TestName).ExecuteTearDown();
        }

        private const string FormName = "NewForm";
        private const string FileFieldController = "FileFieldController";
        private const string PageName = "FormPage";
        private const string TemplateName = "Write.DefaultFileUploadNew";
        private const string TemplateNameNew = "DefaultFileUploadNew";
        private const string TemplateNameFile = "DefaultFileUploadFile";
        private const string TemplateContentFile = "File system template";
        private const string TemplateContent = "This is test content";
    }
}

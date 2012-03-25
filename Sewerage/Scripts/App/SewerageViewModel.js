/// <reference path="../_references.js" />

function SewerageViewModel() {
    // Data
    var self = this;
    self.projectDataSource = upshot.dataSources.Projects.refresh();
    
    self.sectionsDataSourceParameters = {};
    self.sectionsDataSource = new upshot.RemoteDataSource({
        providerParameters: { url: "/api/Sewerage", operationName: "GetProjectSections", operationParameters: self.sectionsDataSourceParameters },
        entityType: "Section:#Sewerage.Models",
        bufferChanges: true,
        dataContext: undefined,
        mapping: { }
    });

    self.inspectionsDataSourceParameters = {};
    self.inspectionsDataSource = new upshot.RemoteDataSource({
        providerParameters: { url: "/api/Sewerage", operationName: "GetSectionInspections", operationParameters: self.inspectionsDataSourceParameters },
        entityType: "Inspection:#Sewerage.Models",
        bufferChanges: true,
        dataContext: undefined,
        mapping: {}
    });

    self.observationsDataSourceParameters = {};
    self.observationsDataSource = new upshot.RemoteDataSource({
        providerParameters: { url: "/api/Sewerage", operationName: "GetInspectionObservations", operationParameters: self.observationsDataSourceParameters },
        entityType: "Observation:#Sewerage.Models",
        bufferChanges: true,
        dataContext: undefined,
        mapping: {}
    });

    self.projects = self.projectDataSource.getEntities();

    self.chosenProject = ko.observable({ Name: "Sewerage Inspector.", Description: "Please pick a project." });
    self.chosenProjectId = ko.observable();
    self.chosenProjectData = ko.observable();

    self.chosenSectionId = ko.observable();
    self.chosenSectionData = ko.observable();

    self.chosenInspectionId = ko.observable();
    self.chosenInspectionData = ko.observable();

    // Behaviours
    self.goToProject = function (project) {
        self.chosenProject(project);
        self.chosenProjectId(project.ProjectId);
        self.chosenSectionId(null);
        self.chosenSectionData(null);
        self.chosenInspectionId(null);
        self.chosenInspectionData(null);
        self.sectionsDataSourceParameters.projectId = project.ProjectId;
        self.sectionsDataSource.refresh();
        self.chosenProjectData(self.sectionsDataSource.getEntities());
    };

    self.goToSection = function (section) {
        self.chosenSectionId(section.SectionId);
        self.chosenInspectionId(null);
        self.chosenInspectionData(null);
        self.inspectionsDataSourceParameters.sectionId = section.SectionId;
        self.inspectionsDataSource.refresh();
        self.chosenSectionData(self.inspectionsDataSource.getEntities());
    };

    self.goToInspection = function (inspection) {
        self.chosenInspectionId(inspection.InspectionId);
        self.observationsDataSourceParameters.inspectionId = inspection.InspectionId;
        self.observationsDataSource.refresh();
        self.chosenInspectionData(self.observationsDataSource.getEntities());
    };
}
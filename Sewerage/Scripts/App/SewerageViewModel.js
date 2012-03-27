﻿/// <reference path="../_references.js" />
/// <reference path="../silverlight.player.js"/>

function SewerageViewModel() {
    // Data
    var self = this;
    self.projectDataSource = upshot.dataSources.Projects.refresh();
    
    self.sectionsDataSourceParameters = {};
    self.sectionsDataSource = new upshot.RemoteDataSource({
        providerParameters: { url: "/api/Sewerage", operationName: "GetProjectSections", operationParameters: self.sectionsDataSourceParameters },
        entityType: "Section:#Sewerage.Models",
        bufferChanges: false,
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

    self.chosenProjectId = ko.observable();
    self.chosenProjectData = ko.observable();

    self.chosenSectionId = ko.observable();
    self.chosenSectionData = ko.observable();

    self.chosenInspectionId = ko.observable();
    self.chosenInspectionData = ko.observable();

    self.chosenObservationId = ko.observable();

    // Navigation
    self.currentSection = ko.observable();
    self.nav = new NavHistory({
        params: { view: 'default', sectionId: null },
        onNavigate: function (navEntry) {
            var requestedSectionId = navEntry.params.sectionId;
            self.sectionsDataSource.findById(requestedSectionId, self.currentSection);
        }
    });

    self.nav.initialize({ linkToUrl: true });


    // Behaviours
    self.goToProject = function (project) {
        self.nav.navigate({ view: 'default', sectionId: null });
        self.chosenProjectId(project.ProjectId);
        self.chosenSectionId(null);
        self.chosenSectionData(null);
        self.chosenInspectionId(null);
        self.chosenInspectionData(null);
        self.chosenObservationId(null);
        self.sectionsDataSourceParameters.projectId = project.ProjectId;
        self.sectionsDataSource.refresh();
        self.chosenProjectData(self.sectionsDataSource.getEntities());
        setMedia("");
        stop();
    };

    self.goToSection = function (section) {
        self.nav.navigate({ view: 'default', sectionId: null });
        self.chosenSectionId(section.SectionId);
        self.chosenInspectionId(null);
        self.chosenInspectionData(null);
        self.chosenObservationId(null);
        self.inspectionsDataSourceParameters.sectionId = section.SectionId;
        self.inspectionsDataSource.refresh();
        self.chosenSectionData(self.inspectionsDataSource.getEntities());
        setMedia("");
        stop();
    };

    self.goToInspection = function (inspection) {
        self.nav.navigate({ view: 'default', sectionId: null });
        self.chosenInspectionId(inspection.InspectionId);
        self.chosenObservationId(null);
        self.observationsDataSourceParameters.inspectionId = inspection.InspectionId;
        self.observationsDataSource.refresh();
        self.chosenInspectionData(self.observationsDataSource.getEntities());
        setMedia("http://localhost/Videos/" + inspection.VideoUrl() + "/Manifest");
        play();
    };

    self.goToObservation = function (observation) {
        self.nav.navigate({ view: 'default', sectionId: null });
        self.chosenObservationId(observation.ObservationId);
        seekToPosition(observation.SecondsIntoVideo());
    };

    // Operations
    self.showSection = function(section) { self.nav.navigate({ view: 'section', sectionId: section.SectionId() }) };
    self.saveObservations = function () { self.observationsDataSource.commitChanges(); };
    self.revertObservations = function() { self.observationsDataSource.revertChanges(); };
}
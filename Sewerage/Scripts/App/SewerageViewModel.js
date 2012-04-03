/// <reference path="../_references.js" />
/// <reference path="../silverlight.player.js"/>

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

    // Helpers
    self.url = window.location.protocol + "//" + window.location.host + "/";
    self.ribbon = ko.observable("project");

    // Entities
    self.projects = self.projectDataSource.getEntities();
    self.chosenProjectId = ko.observable();
    self.chosenProjectData = ko.observable();
    self.chosenSectionId = ko.observable();
    self.chosenSectionData = ko.observable();
    self.chosenInspectionId = ko.observable();
    self.chosenInspectionData = ko.observable();
    self.chosenObservationId = ko.observable();

    // Behaviours
    self.chosenProjectId.subscribe(function () {
        self.chosenSectionId(null);
        self.chosenSectionData(null);
    });

    self.chosenSectionId.subscribe(function () {
        self.chosenInspectionId(null);
        self.chosenInspectionData(null);
    });

    self.chosenInspectionId.subscribe(function () {
        self.chosenObservationId(null);
    });

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


    // Operations
    self.goToProject = function (project) {
        self.chosenProjectId(project.ProjectId);

        self.nav.navigate({ view: 'default', sectionId: null });
        self.ribbon("project");

        self.sectionsDataSourceParameters.projectId = self.chosenProjectId();
        self.sectionsDataSource.refresh();
        self.chosenProjectData(self.sectionsDataSource.getEntities());
        
        setMedia("");
        stop();
    };

    self.goToSection = function (section) {
        self.chosenSectionId(section.SectionId);
        
        self.nav.navigate({ view: 'default', sectionId: null });
        self.ribbon("section");

        self.inspectionsDataSourceParameters.sectionId = self.chosenSectionId();
        self.inspectionsDataSource.refresh();
        self.chosenSectionData(self.inspectionsDataSource.getEntities());
        
        setMedia("");
        stop();
    };

    self.goToInspection = function (inspection) {
        self.chosenInspectionId(inspection.InspectionId);

        self.nav.navigate({ view: 'default', sectionId: null });
        self.ribbon("inspection");

        self.observationsDataSourceParameters.inspectionId = self.chosenInspectionId();
        self.observationsDataSource.refresh();
        self.chosenInspectionData(self.observationsDataSource.getEntities());
        
        self.videoUrl = self.url + "Videos/" + inspection.VideoUrl() + "/Manifest";
        setMedia(self.videoUrl);
        play();
    };

    self.goToObservation = function (observation) {
        self.chosenObservationId(observation.ObservationId);
        
        self.nav.navigate({ view: 'default', sectionId: null });
        self.ribbon("observation");
        
        seekToPosition(observation.SecondsIntoVideo());
    };

    self.showSection = function (section) { self.nav.navigate({ view: 'section', sectionId: section.SectionId() }) };
    self.newSection = function () { alert("not implemented yet"); };
    self.saveSections = function () { self.sectionsDataSource.commitChanges(); };
    self.revertSections = function () { self.sectionsDataSource.revertChanges(); };

    self.newObservation = function () { alert("not implemented yet"); };
    self.saveObservations = function () { self.observationsDataSource.commitChanges(); };
    self.revertObservations = function() { self.observationsDataSource.revertChanges(); };
}
﻿/// <reference path="../_references.js" />


(function (window, undefined) {
    // define the namespace
    var Sewerage = window.Sewerage = window.Sewerage || {};


    // project classes
    var projectEntityType = "Project:#Sewerage.Models";
    var sectionEntityType = "Section:#Sewerage.Models";
    var inspectionEntityType = "Inspection:#Sewerage.Models";
    var observationEntityType = "Observation:#Sewerage.Models";


    // define the client models
    Sewerage.Project = function (data) {
        var self = this;

        // add properties from the JSON data result
        upshot.map(data, projectEntityType, self);

        // add properties managed by upshot
        upshot.addEntityProperties(self);
    };

    Sewerage.Section = function (data) {
        var self = this;

        // add properties from the JSON data result
        upshot.map(data, sectionEntityType, self);

        // add properties managed by upshot
        upshot.addEntityProperties(self);
    };

    Sewerage.Inspection = function (data) {
        var self = this;

        // add properties from the JSON data result
        upshot.map(data, inspectionEntityType, self);

        // add properties managed by upshot
        upshot.addEntityProperties(self);
    };

    Sewerage.Observation = function (data) {
        var self = this;

        // add properties from the JSON data result
        upshot.map(data, observationEntityType, self);

        // add properties managed by upshot
        upshot.addEntityProperties(self);
    };


    // define the view model
    Sewerage.SewerageViewModel = function (options) {
        var self = this;

        // public array to bind to HTML
        self.Projects = ko.observableArray();
        self.Sections = ko.observableArray();
        self.Inspections = ko.observableArray();
        self.Observations = ko.observableArray();

        // public ids of chosen objects
        self.ChosenProjectId = ko.observable();
        self.ChosenSectionId = ko.observable();
        self.ChosenInspectionId = ko.observable();
        self.ChosenObservationId = ko.observable();

        // editing items
        self.EditingSection = ko.observable();
        self.EditingObservation = ko.observable();

        // helpers
        self.Url = window.location.protocol + "//" + window.location.host + "/";
        self.Ribbon = ko.observable("project");

        // data sources
        var projectsDataSourceOptions = {
            providerParameters: { url: options.serviceUrl, operationName: "GetProjects" },
            bufferChanges: true,
            entityType: projectEntityType,
            mapping: Sewerage.Project,
            result: self.Projects
        };
        var projectsDataSource = new upshot.RemoteDataSource(projectsDataSourceOptions).refresh();

        var dataContext = projectsDataSource.getDataContext(); // get a common context

        var sectionsDataSourceParameters = {};
        var sectionsDataSourceOptions = {
            providerParameters: { url: options.serviceUrl, operationName: "GetProjectSections", operationParameters: sectionsDataSourceParameters },
            bufferChanges: true,
            dataContext: dataContext,
            entityType: sectionEntityType,
            mapping: Sewerage.Section,
            result: self.Sections
        };
        var sectionsDataSource = new upshot.RemoteDataSource(sectionsDataSourceOptions);

        var inspectionsDataSourceParameters = {};
        var inspectionsDataSourceOptions = {
            providerParameters: { url: options.serviceUrl, operationName: "GetSectionInspections", operationParameters: inspectionsDataSourceParameters },
            bufferChanges: true,
            dataContext: dataContext,
            entityType: inspectionEntityType,
            mapping: Sewerage.Inspection,
            result: self.Inspections
        };
        var inspectionsDataSource = new upshot.RemoteDataSource(inspectionsDataSourceOptions);

        var observationsDataSourceParameters = {};
        var observationsDataSourceOptions = {
            providerParameters: { url: options.serviceUrl, operationName: "GetInspectionObservations", operationParameters: observationsDataSourceParameters },
            bufferChanges: true,
            dataContext: dataContext,
            entityType: observationEntityType,
            mapping: Sewerage.Observation,
            result: self.Observations
        };
        var observationsDataSource = new upshot.RemoteDataSource(observationsDataSourceOptions);

        // behaviours
        self.ChosenProjectId.subscribe(function () {
            self.ChosenSectionId(null);
        });

        self.ChosenSectionId.subscribe(function () {
            self.ChosenInspectionId(null);
        });

        self.ChosenInspectionId.subscribe(function () {
            self.ChosenObservationId(null);
        });

        // client side navigation
        self.nav = new NavHistory({
            params: { editSection: null, editObservation: null },
            onNavigate: function (navEntry, navInfo) {

                if (navEntry.params.editSection) {

                    if (navEntry.params.editSection == "new") {
                        // Create and begin editing a new section instance
                        var section = new Sewerage.Section({ ProjectId: self.ChosenProjectId() });
                        self.EditingSection(section);
                        self.Sections.push(section);
                    } else {
                        // Load and begin editing an existing section instance
                        var sectionId = navEntry.params.editSection;
                        sectionsDataSource.findById(sectionId, self.EditingSection);
                    }
                } else if (navEntry.params.editObservation) {

                    if (navEntry.params.editObservation == "new") {
                        // Create and begin editing a new observation instance
                        var observation = new Sewerage.Observation({ InspectionId: self.ChosenInspectionId() });
                        self.EditingObservation(observation);
                        self.Observations.push(observation);
                    } else {
                        // Load and begin editing an existing observation instance
                        var observationId = navEntry.params.editObservation;
                        observationsDataSource.findById(observationId, self.EditingObservation);
                    }

                } else {
                    // reset editors
                    self.EditingSection(null);
                    self.EditingObservation(null);
                    
                    //sectionsDataSource.revertChanges();
                    //observationsDataSource.revertChanges();
                }
            }

        }).initialize({ linkToUrl: true });

        // operations
        self.selectProject = function (project) {
            self.ChosenProjectId(project.ProjectId);
            sectionsDataSourceParameters.projectId = self.ChosenProjectId();
            sectionsDataSource.refresh();
            self.Ribbon("project");
            setMedia("");
            stop();
        };

        self.selectSection = function (section) {
            self.ChosenSectionId(section.SectionId);
            inspectionsDataSourceParameters.sectionId = self.ChosenSectionId();
            inspectionsDataSource.refresh();

            //self.selectInspection(self.Inspections()[0]);

            self.Ribbon("section");
            setMedia("");
            stop();
        };

        self.selectInspection = function (inspection) {
            self.ChosenInspectionId(inspection.InspectionId);
            observationsDataSourceParameters.inspectionId = self.ChosenInspectionId();
            observationsDataSource.refresh();
            //self.Ribbon("inspection");
            var videoUrl = self.Url + "Videos/" + inspection.VideoUrl() + "/Manifest";
            setMedia(videoUrl);
            play();
        };

        self.selectObservation = function (observation) {
            self.ChosenObservationId(observation.ObservationId);
            self.Ribbon("observation");
            seekToPosition(observation.SecondsIntoVideo());
        };

        // sections
        self.editSection = function (section) { self.nav.navigate({ editSection: section.SectionId() }); };
        self.createSection = function () { self.nav.navigate({ editSection: "new" }); };
        self.deleteSection = function (section) {
            sectionsDataSource.deleteEntity(section);
            sectionsDataSource.commitChanges(function () {
                self.showDefaultView();
            });
        };
        self.saveSections = function () {
            sectionsDataSource.commitChanges();
            self.showDefaultView();
        };
        self.revertSections = function () { sectionsDataSource.revertChanges(); };

        // observations
        self.editObservation = function (observation) { self.nav.navigate({ editObservation: observation.ObservationId() }); };
        self.createObservation = function () { self.nav.navigate({ editObservation: "new" }); };
        self.deleteObservation = function (observation) {
            observationsDataSource.deleteEntity(observation);
            observationsDataSource.commitChanges(function () {
                self.showDefaultView();
            });
        };
        self.saveObservations = function () {
            observationsDataSource.commitChanges();
            self.showDefaultView();
        };
        self.revertObservations = function () { observationsDataSource.revertChanges(); };

        // general
        self.showDefaultView = function () { self.nav.navigate({ editSection: null, editObservation: null }); };
    };
})(window);
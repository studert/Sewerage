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
        self.EditingInspection = ko.observable();
        self.EditingObservation = ko.observable();

        // helpers
        self.Url = window.location.protocol + "//" + window.location.host + "/";

        // callbacks
        var selectFirstSection = function() {
            var firstSection = self.Sections()[0];
            self.selectSection(firstSection);
        };

        var selectFirstInspection = function() {
            var firstInspection = self.Inspections()[0];
            self.selectInspection(firstInspection);
        };

        var selectFirstObservation = function() {
            var firstObservation = self.Observations()[0];
            self.selectObservation(firstObservation);
        };

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
        
        var clearAllEdits = function() {
            self.EditingSection(null);
            self.EditingInspection(null);
            self.EditingObservation(null);
        };

        var revertAllDataSources = function() {
            self.revertSections();
            self.revertInspections();
            self.revertObservations();
        };

        var resetEditors = function() {
            revertAllDataSources();
            clearAllEdits();
        };
        
        // notifications
        self.successMessage = ko.observable().extend({ notify: "always" });
        self.errorMessage = ko.observable().extend({ notify: "always" });
        
        // player
        var createPlayer = function(videoUrl) {
            // reset html for player
            var frame = $("#playerFrame");
            frame.empty();
            frame.append('<div id="myVideoContainer" class="pf-container"></div>');
            
            // sources
            var urlBase = self.Url + videoUrl;
            var ism = urlBase + ".ism/manifest";
            var mp4 = urlBase + ".mp4";
            var webm = urlBase + ".webm";
            var ogv = urlBase + ".ogv";
            
            // recreate html for player
            self.player = new PlayerFramework.Player("myVideoContainer",
            {
                mediaPluginFallbackOrder: [ "SilverlightMediaPlugin", "VideoElementMediaPlugin" ], 
                width: "350px",
                height: "320px",
                poster: self.Url + "Content/images/poster.png",
                autoplay: true,
                sources:
                [
                    {
                        src: ism,
                        type: "text/xml"
                    },
                    {
                        src: mp4,
                        type: 'video/mp4; codecs="avc1.42E01E, mp4a.40.2"'
                    },
                    {
                        src: webm,
                        type: 'video/webm; codecs="vp8, vorbis"'
                    },
                    {
                        src: ogv,
                        type: 'video/ogg; codecs="theora, vorbis"'
                    }
                ]
            });
        };

        // operations
        self.selectProject = function (project) {
            // reset all editors
            self.showDefaultView();

            self.ChosenProjectId(project.ProjectId);
            sectionsDataSourceParameters.projectId = self.ChosenProjectId();
            sectionsDataSource.refresh({ }, selectFirstSection);
        };

        self.selectSection = function(section) {
            self.ChosenSectionId(section.SectionId);
            inspectionsDataSourceParameters.sectionId = self.ChosenSectionId();
            inspectionsDataSource.refresh({ }, selectFirstInspection);
        };

        self.selectInspection = function (inspection) {
//            var videoUrl = self.Url + "Videos/" + inspection.VideoUrl() + "/Manifest";
            createPlayer(inspection.VideoUrl());
            
            self.ChosenInspectionId(inspection.InspectionId);
            observationsDataSourceParameters.inspectionId = self.ChosenInspectionId();
            observationsDataSource.refresh({ }, selectFirstObservation);
        };

        self.selectObservation = function (observation) {
            self.player.currentTime(observation.SecondsIntoVideo());
            
            self.ChosenObservationId(observation.ObservationId);
        };

        // sections
        self.editSection = function (section) { self.EditingSection(section); };
        self.createSection = function() {
            var section = new Sewerage.Section({ ProjectId: self.ChosenProjectId() });
            self.EditingSection(section);
            self.Sections.push(section);
        };
        self.deleteSection = function (section) {
            if (confirm("Are you sure you want to delete this?")) {
                sectionsDataSource.deleteEntity(section);
                sectionsDataSource.commitChanges(function() {
                    self.successMessage("Deleted section");
                    self.showDefaultView();
                });
            }
        };
        self.saveSections = function (form) {
            if(!$(form).valid()) { return false; }
            
            sectionsDataSource.commitChanges(function() {
                self.successMessage("Saved section changes");
                self.showDefaultView();
            });
        };
        self.revertSections = function () { sectionsDataSource.revertChanges(); };
        
        // inspections
        self.editInspection = function (inspection) { self.EditingInspection(inspection); };
        self.createInspection = function() {
            var inspection = new Sewerage.Inspection({ SectionId: self.ChosenSectionId() });
            self.EditingInspection(inspection);
            self.Inspections.push(inspection);
        };
        self.deleteInspection = function (inspection) {
            if (confirm("Are you sure you want to delete this?")) {
                inspectionsDataSource.deleteEntity(inspection);
                inspectionsDataSource.commitChanges(function() {
                    self.successMessage("Deleted inspection");
                    self.showDefaultView();
                });
            }
        };
        self.saveInspections = function (form) {
            if(!$(form).valid()) { return false; }
            
            inspectionsDataSource.commitChanges(function() {
                self.successMessage("Saved inspection changes");
                self.showDefaultView();
            });
        };
        self.revertInspections = function () { inspectionsDataSource.revertChanges(); };

        // observations
        self.editObservation = function (observation) { self.EditingObservation(observation); };
        self.createObservation = function() {
            var observation = new Sewerage.Observation({ InspectionId: self.ChosenInspectionId() });
            self.EditingObservation(observation);
            self.Observations.push(observation);
        };
        self.deleteObservation = function (observation) {
            if (confirm("Are you sure you want to delete this?")) {
                observationsDataSource.deleteEntity(observation);
                observationsDataSource.commitChanges(function() {
                    self.successMessage("Deleted observation");
                    self.showDefaultView();
                });
            }
        };
        self.saveObservations = function (form) {
            if(!$(form).valid()) { return false; }
            
            observationsDataSource.commitChanges(function() {
                self.successMessage("Saved observation changes");
                self.showDefaultView();
            });
        };
        self.revertObservations = function () { observationsDataSource.revertChanges(); };

        // general
        self.showDefaultView = function () { resetEditors(); };
        
        // error handling
        var handleServerError = function(httpStatus, message) {
            if (status === 200) {
                // application domain error (e.g., validation error)
                self.errorMessage(message);
            } else {
                // system error (e.g., unhandled exception)
                self.errorMessage("Server error: HTTP status code: " + httpStatus + ", message: " + message);
            }
        };

        projectsDataSource.bind({ refreshError: handleServerError, commitError: handleServerError });
        sectionsDataSource.bind({ refreshError: handleServerError, commitError: handleServerError });
        inspectionsDataSource.bind({ refreshError: handleServerError, commitError: handleServerError });
        observationsDataSource.bind({ refreshError: handleServerError, commitError: handleServerError });
    };
})(window);
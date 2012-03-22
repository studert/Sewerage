/// <reference path="../_references.js" />

function ObservationsViewModel() {
    // Data
    var self = this;
    self.dataSource = upshot.dataSources.Observations.refresh();
    self.localDataSource = upshot.LocalDataSource({ source: self.dataSource, autoRefresh: true });

    self.observations = self.localDataSource.getEntities();
    self.observationsForInspections = self.observations.groupBy("Inspection");
}
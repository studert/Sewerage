/// <reference path="../_references.js" />

function ProjectsViewModel() {
    // Data
    var self = this;
    self.dataSource = upshot.dataSources.Projects.refresh();
    self.localDataSource = upshot.LocalDataSources({ source: self.dataSource, autoRefresh: true });
    
    self.projects = self.localDataSource.getEntities();
}
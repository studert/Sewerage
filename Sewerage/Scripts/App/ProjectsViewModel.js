function ProjectsViewModel() {
    // Data
    var self = this;
    self.dataSource = upshot.dataSources.Projects.refresh();
    
    self.projects = self.dataSource.getEntities();
}
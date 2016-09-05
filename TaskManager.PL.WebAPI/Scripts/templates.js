angular.module("templates", []).run(["$templateCache", function($templateCache) {$templateCache.put("AddProjectPage.html","<div class=\"form-group\">\r\n    <md-content md-theme=\"docs-dark\"\r\n                layout-padding\r\n                class=\"login-form\">\r\n        <md-input-container class=\"md-block md-input-has-value\">\r\n\r\n            <label for=\"projectName\">Название проекта</label>\r\n            <input ng-required=\"true\"\r\n                   name=\"projectName\"\r\n                   ng-model=\"projectName\"\r\n                   class=\"ng-pristine md-input ng-invalid ng-invalid-required ng-touched\"\r\n                   id=\"projectName\" />\r\n\r\n        </md-input-container>\r\n        <md-input-container class=\"md-block md-input-has-value\">\r\n            <label for=\"summary\">Краткое описание проекта</label>\r\n\r\n            <input name=\"summary\"\r\n                   id=\"summary\"\r\n                   ng-model=\"projectSummary\"\r\n                   type=\"text\" />\r\n        </md-input-container>\r\n    </md-content>\r\n\r\n    <md-button ng-click=\"answer({ProjectName: projectName, Summary: projectSummary })\">\r\n        Добавить\r\n    </md-button>\r\n</div>");
$templateCache.put("AddTaskPage.html","<div class=\"form-group\">\r\n    <md-content md-theme=\"docs-dark\"\r\n                layout-padding\r\n                class=\"login-form\">\r\n\r\n        <md-input-container class=\"md-block md-input-has-value\">\r\n            <label for=\"taskName\">Название задачи</label>\r\n            <input ng-required=\"true\"\r\n                   name=\"taskName\"\r\n                   ng-model=\"taskName\"\r\n                   class=\"ng-pristine md-input ng-invalid ng-invalid-required ng-touched\"\r\n                   id=\"taskName\" />\r\n        </md-input-container>\r\n\r\n        <md-input-container class=\"md-block md-input-has-value\">\r\n            <label for=\"summary\">Краткое описание задачи</label>\r\n\r\n            <input name=\"summary\"\r\n                   id=\"summary\"\r\n                   ng-model=\"taskSummary\"\r\n                   type=\"text\" />\r\n        </md-input-container>\r\n\r\n        <label for=\"summary\">Крaйняя дата выполнения задачи</label>\r\n        <md-datepicker ng-model=\"taskDeadline\"\r\n                       md-placeholder=\"Enter date\"\r\n                       md-min-date=\"minDate\"\r\n                       md-open-on-focus>\r\n        </md-datepicker>\r\n\r\n    </md-content>\r\n\r\n    <md-button ng-click=\"answer({ProjectId: projectId, Name: taskName, Summary: taskSummary, DeadLine: taskDeadline})\">\r\n        Добавить\r\n    </md-button>\r\n</div>");
$templateCache.put("Home.html","<div class=\"home-page\">\r\n    <div class=\"modal-footer\">\r\n        <button type=\"submit\"\r\n                class=\"btn btn-default\"\r\n                ui-sref=\"registrationpage\">\r\n            Зарегистрироваться\r\n        </button>\r\n        <button class=\"btn btn-info\"\r\n                ui-sref=\"loginpage\">\r\n            Login\r\n        </button>\r\n        <button class=\"btn btn-info\"\r\n                ng-click=\"home.check()\">\r\n            IsOk\r\n        </button>\r\n    </div>\r\n    <div class=\"top-container\">\r\n        <div class=\"left-side\">\r\n            <!--Вот так подключаются подвьюшки-->\r\n            <div ng-include\r\n                 src=\"\'LoginPage.html\'\"\r\n                 ng-controller=\"LoginCtrl as loginpage\">\r\n            </div>\r\n        </div>\r\n        <div class=\"right-side\">\r\n            <div class=\"slogan\">\r\n                Создавайте проекты, распределяйте задачи, отслеживайте активность проектной команды. <br />\r\n                Лидер - будь впереди!\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>");
$templateCache.put("LoginPage.html","<form novalidate name=\"loginForm\" ng-submit=\"loginForm.$valid && loginpage.loginGo()\">\r\n    <!--позвали this.loginGo()-->\r\n    <div class=\"form-group\">\r\n        <md-content md-theme=\"docs-dark\"\r\n                    layout-padding\r\n                    class=\"login-form\">\r\n            <md-input-container class=\"md-block md-input-has-value\">\r\n\r\n                <label for=\"login\">Логин</label>\r\n                <input name=\"login\"\r\n                       ng-model=\"loginpage.login\"\r\n                       class=\"ng-pristine md-input ng-invalid ng-invalid-required ng-touched\"\r\n                       id=\"login\"\r\n                       ng-required=\"true\" />\r\n\r\n            </md-input-container>\r\n            <md-input-container class=\"md-block md-input-has-value\">\r\n                <label for=\"password\">Пароль</label>\r\n\r\n                <input id=\"password\"\r\n                       ng-model=\"loginpage.password\"\r\n                       type=\"password\"\r\n                       name=\"password\"\r\n                       ng-required=\"true\" />\r\n            </md-input-container>\r\n        </md-content>\r\n\r\n        <md-button class=\"md-raised submit-btn\" type=\"submit\">Войти</md-button>\r\n    </div>\r\n</form>");
$templateCache.put("ProjectPage.html","<div>\r\n\r\n    <md-button class=\"md-primary md-raised\" ng-click=\"projectpage.showAddTaskDialog($event)\">\r\n        Добавить задачу\r\n    </md-button>\r\n\r\n    <div class=\"task-container\">\r\n        <div class=\"task-item\"\r\n             ng-repeat=\"task in projectpage.tasks track by $index\">\r\n            <div class=\"tasks-title\">\r\n                {{::task.Name}}<!-- ::  <=== it is one time data binding in angularjs-->\r\n            </div>\r\n            <div class=\"project-summary\">\r\n                {{::task.Summary}}\r\n            </div>\r\n            <div class=\"project-summary\">\r\n                {{::task.CreationTime}}\r\n            </div>\r\n            <div class=\"project-summary\">\r\n                {{::task.Deadline}}\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
$templateCache.put("RegistrationPage.html","<form novalidate name=\"registrationForm\" \r\n      ng-submit=\"registrationForm.$valid && registrationpage.createNewAccount()\">\r\n    <div class=\"form-group\">\r\n        <label for=\"login\">Логин</label>\r\n        <input placeholder=\"Логин\"\r\n               id=\"login\"\r\n               ng-model=\"registrationpage.login\"\r\n               type=\"text\"\r\n               name=\"login\"\r\n               ng-required=\"true\" />\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"password\">Пароль</label>\r\n        <input placeholder=\"Пароль\"\r\n               id=\"password\"\r\n               ng-model=\"registrationpage.password\"\r\n               type=\"password\"\r\n               name=\"password\"\r\n               ng-required=\"true\" />\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"password\">Повторите пароль</label>\r\n        <input placeholder=\"Повторите пароль\"\r\n               id=\"password\"\r\n               ng-model=\"registrationpage.confirmPassword\"\r\n               type=\"password\"\r\n               name=\"password\"\r\n               ng-required=\"true\" />\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"password\">Электронная почта</label>\r\n        <input placeholder=\"Электронная почта\"\r\n               id=\"email\"\r\n               ng-model=\"registrationpage.email\"\r\n               type=\"email\"\r\n               name=\"email\"\r\n               ng-required=\"true\" />\r\n    </div>\r\n    <button type=\"submit\" class=\"btn btn-default\">Submit</button>\r\n</form>");
$templateCache.put("UserPage.html","<div class=\"user-page\">\r\n    <button class=\"btn btn-default\" ng-click=\"userpage.logoutGo()\">Выйти</button>\r\n\r\n    <md-button class=\"md-primary md-raised\" ng-click=\"userpage.showAddProjectDialog($event)\">\r\n        Создать проект\r\n    </md-button>\r\n\r\n    <div class=\"projects-container\">\r\n        <div class=\"project-item\"\r\n             ng-repeat=\"project in userpage.projects track by $index\"\r\n             ui-sref=\"projectpage({projectId: project.Id})\">\r\n            <div class=\"project-title\">\r\n                {{::project.ProjectName}}<!--model-->\r\n            </div>\r\n            <div class=\"project-summary\">\r\n                {{::project.Summary}}\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n</div>\r\n");}]);
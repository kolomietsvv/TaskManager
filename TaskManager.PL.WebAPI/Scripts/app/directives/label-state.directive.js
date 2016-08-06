'use strict';

App.directive('labelState', function ($timeout) {
    return {
        link: function (scope, element, attrs) {
            var label = element.parent().find('label');

            function labelStateChange(event) {
                if (event.type === 'focus') {
                    label.addClass('active');
                } else if (event.type === 'blur' && !element.val()) {
                    label.removeClass('active');
                }
            }

            element.on('focus blur', labelStateChange);

            scope.$watch(attrs.ngModel, function (newValue) {
                $timeout(function () {
                    if (newValue) {
                        label.addClass('active');
                    } else if (!newValue && !label.is(':focus')) {
                        label.removeClass('active');
                    }
                });
            });

            scope.$on('$destroy', function () {
                element.off('focus blur', labelStateChange);
            });
        }
    };
});

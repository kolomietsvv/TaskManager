var gulp = require('gulp'),
    runSequence = require('run-sequence');

gulp.paths = {
    templates: {
        src: './templates/*.html',
        dest: './Scripts/'
    },
    styles: {
        src: ['./Content/scss/**/*.scss', './bower_components/bootstrap-sass/assets/stylesheets/**/*.scss'],
        dest: './Styles/css/'
    }
};

require('require-dir')('./gulp');

gulp.task('serve', function () {
    runSequence(['templateCache', 'styles', 'watch']);
});

gulp.task('run', function () {
    runSequence(['templateCache', 'styles', 'watch']);
});
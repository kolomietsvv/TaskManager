var gulp = require('gulp'),
    del = require('del'),
    runSequence = require('run-sequence'),
    autoprefixer = require('gulp-autoprefixer'),
    sass = require('gulp-sass'),
    cssmin = require('gulp-minify-css'),
    concat = require('gulp-concat'),
    paths = gulp.paths;

gulp.task('styles', function () {
    runSequence(['cleanStyles', 'buildStyles']);
});

gulp.task('cleanStyles', function () {
    del([paths.styles.dest + '/allStyles.css']);
});

gulp.task('buildStyles', function () {
    gulp.src(paths.styles.src)
        .pipe(sass({
            sourceMap: true,
            errLogToConsole: true
        }).on('error', sass.logError))
        .pipe(autoprefixer("last 3 version", "safari 5", "ie 9"))
        .pipe(concat('allStyles.css'))
        .pipe(cssmin())
        .pipe(gulp.dest(paths.styles.dest));
});
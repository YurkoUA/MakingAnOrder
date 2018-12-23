module.exports = function (config) {
    config.set({
        basePath: '../../',
        frameworks: ['jasmine'],
        files: [
            'MakingAnOrder/Scripts/polyfills.js',
            'MakingAnOrder/Scripts/toastr.min.js',
            'MakingAnOrder/Scripts/moment.min.js',
            'MakingAnOrder/Scripts/jquery-3.3.1.min.js',
            'MakingAnOrder/Scripts/jquery.validate.min.js',
            'MakingAnOrder/Scripts/jquery.validate.unobtrusive.min.js',
            'MakingAnOrder/Scripts/knockout-3.4.2.js',
            'MakingAnOrder/Scripts/knockout.mapping-latest.js',
            'MakingAnOrder/Scripts/bootstrap.min.js',
            'MakingAnOrder/Scripts/bootstrap-datepicker.min.js',

            'MakingAnOrder/Scripts/app/services/*',
            'MakingAnOrder/Scripts/app/constants.js',
            'MakingAnOrder/Scripts/app/app-navbar.js',
            'MakingAnOrder/Scripts/app/main-page.js',
            'MakingAnOrder/Scripts/app/product-create.js',
            'MakingAnOrder/Scripts/app/purchase.js',
            'MakingAnOrder/Scripts/app/order-history.js',
            'MakingAnOrder.Tests/JSTests/tests/*-test.js'
        ],
        plugins: [
            'karma-*'
        ],
        preprocessors: {},
        reporters: ['progress', 'junit', 'kjhtml'],
        // web server port
        port: 9876,
        browsers: ['Chrome'],
        singleRun: true,
        concurrency: Infinity,
        // the default configuration
        junitReporter: {
            outputDir: 'test-reports', // results will be saved as $outputDir/$browserName.xml
            outputFile: 'junit-report.xml', // if included, results will be saved as $outputDir/$browserName/$outputFile
            suite: '', // suite will become the package name attribute in xml testsuite element
            useBrowserName: true, // add browser name to report and classes names
            nameFormatter: undefined, // function (browser, result) to customize the name attribute in xml testcase element
            classNameFormatter: undefined, // function (browser, result) to customize the classname attribute in xml testcase element
            properties: {} // key value pair of properties to add to the section of the report
        },
        client: {
            jasmine: {
                random: false
            }
        }
    });
}
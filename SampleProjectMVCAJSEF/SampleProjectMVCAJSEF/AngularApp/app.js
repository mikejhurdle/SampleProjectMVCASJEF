var app = angular.module('App', ['ngMaterial', 'angularUtils.directives.dirPagination','googlechart']);
app.config(function ($mdThemingProvider) {
    var customPrimary = {
        '50': '#ffffff',
        '100': '#ffffff',
        '200': '#e5f5ff',
        '300': '#ccebff',
        '400': '#b3e0ff',
        '500': '#99d6ff',
        '600': '#80ccff',
        '700': '#66c1ff',
        '800': '#4db7ff',
        '900': '#33adff',
        'A100': '#ffffff',
        'A200': '#ffffff',
        'A400': '#ffffff',
        'A700': '#1aa3ff'
    };
    $mdThemingProvider
        .definePalette('customPrimary',
            customPrimary);

    var customAccent = {
        '50': '#33ffff',
        '100': '#4dffff',
        '200': '#66ffff',
        '300': '#80ffff',
        '400': '#99ffff',
        '500': '#b3ffff',
        '600': '#e5ffff',
        '700': '#ffffff',
        '800': '#ffffff',
        '900': '#ffffff',
        'A100': '#e5ffff',
        'A200': '#ccffff',
        'A400': '#b3ffff',
        'A700': '#ffffff'
    };
    $mdThemingProvider
        .definePalette('customAccent',
            customAccent);

    var customWarn = {
        '50': '#ffb280',
        '100': '#ffa266',
        '200': '#ff934d',
        '300': '#ff8333',
        '400': '#ff741a',
        '500': '#ff6400',
        '600': '#e65a00',
        '700': '#cc5000',
        '800': '#b34600',
        '900': '#993c00',
        'A100': '#ffc199',
        'A200': '#ffd1b3',
        'A400': '#ffe0cc',
        'A700': '#803200'
    };
    $mdThemingProvider
        .definePalette('customWarn',
            customWarn);

    var customBackground = {
        '50': '#ccddff',
        '100': '#b3ccff',
        '200': '#99bbff',
        '300': '#80aaff',
        '400': '#6699ff',
        '500': '#4d88ff',
        '600': '#3377ff',
        '700': '#1a66ff',
        '800': '#0055ff',
        '900': '#004ce6',
        'A100': '#e6eeff',
        'A200': '#ffffff',
        'A400': '#ffffff',
        'A700': '#0044cc'
    };
    $mdThemingProvider
        .definePalette('customBackground',
            customBackground);

    $mdThemingProvider.theme('default')
        .primaryPalette('customPrimary')
        .accentPalette('customAccent')
        .warnPalette('customWarn')
        //.backgroundPalette('customBackground');
});

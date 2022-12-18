$(function ()
{
    $('#sidebar-toggle-button').on('click', function () {
        $('#sidebar').toggleClass('sidebar-toggle');
        $('#page-content-wrapper').toggleClass('page-content-toggle');
        fireResize();
        $('#gridContainer').toggleClass('widt-100vw')
    });

    $('#sidebar').on('show.bs.collapse', function () {
        $('#sidebar').find('.collapse.in').collapse('hide');
    });

    (function addActiveClassToNestedList() {
        var pageURL = $(location).attr('href');
        var URLSplits = pageURL.split('/');

        var routeURL = '/' + URLSplits[URLSplits.length - 3] + '/' + URLSplits[URLSplits.length - 2] + '/';
        var activeNestedList = $('.sub-menu > li > a[href="' + routeURL + '"]').parent();

        if (activeNestedList.length !== 0 && !activeNestedList.hasClass('active')) {
            $('.sub-menu > li').removeClass('active');
            activeNestedList.addClass('active');
        }
    })();

    function fireResize()
    {
        if (document.createEvent) {
            var ev = document.createEvent('Event');
            ev.initEvent('resize', true, true);
            window.dispatchEvent(ev);
        }
        else {
            element = document.documentElement;
            var event = document.createEventObject();
            element.fireEvent("onresize", event);
        }
    }

});
/*
 * jQuery Easing v1.3 - http://gsgd.co.uk/sandbox/jquery/easing/
 *
 * 
*/
jQuery.easing["jswing"]=jQuery.easing["swing"];jQuery.extend(jQuery.easing,{def:"easeOutQuad",swing:function(a,b,c,d,e){return jQuery.easing[jQuery.easing.def](a,b,c,d,e)},easeInQuad:function(a,b,c,d,e){return d*(b/=e)*b+c},easeOutQuad:function(a,b,c,d,e){return-d*(b/=e)*(b-2)+c},easeInOutQuad:function(a,b,c,d,e){if((b/=e/2)<1)return d/2*b*b+c;return-d/2*(--b*(b-2)-1)+c},easeInCubic:function(a,b,c,d,e){return d*(b/=e)*b*b+c},easeOutCubic:function(a,b,c,d,e){return d*((b=b/e-1)*b*b+1)+c},easeInOutCubic:function(a,b,c,d,e){if((b/=e/2)<1)return d/2*b*b*b+c;return d/2*((b-=2)*b*b+2)+c},easeInQuart:function(a,b,c,d,e){return d*(b/=e)*b*b*b+c},easeOutQuart:function(a,b,c,d,e){return-d*((b=b/e-1)*b*b*b-1)+c},easeInOutQuart:function(a,b,c,d,e){if((b/=e/2)<1)return d/2*b*b*b*b+c;return-d/2*((b-=2)*b*b*b-2)+c},easeInQuint:function(a,b,c,d,e){return d*(b/=e)*b*b*b*b+c},easeOutQuint:function(a,b,c,d,e){return d*((b=b/e-1)*b*b*b*b+1)+c},easeInOutQuint:function(a,b,c,d,e){if((b/=e/2)<1)return d/2*b*b*b*b*b+c;return d/2*((b-=2)*b*b*b*b+2)+c},easeInSine:function(a,b,c,d,e){return-d*Math.cos(b/e*(Math.PI/2))+d+c},easeOutSine:function(a,b,c,d,e){return d*Math.sin(b/e*(Math.PI/2))+c},easeInOutSine:function(a,b,c,d,e){return-d/2*(Math.cos(Math.PI*b/e)-1)+c},easeInExpo:function(a,b,c,d,e){return b==0?c:d*Math.pow(2,10*(b/e-1))+c},easeOutExpo:function(a,b,c,d,e){return b==e?c+d:d*(-Math.pow(2,-10*b/e)+1)+c},easeInOutExpo:function(a,b,c,d,e){if(b==0)return c;if(b==e)return c+d;if((b/=e/2)<1)return d/2*Math.pow(2,10*(b-1))+c;return d/2*(-Math.pow(2,-10*--b)+2)+c},easeInCirc:function(a,b,c,d,e){return-d*(Math.sqrt(1-(b/=e)*b)-1)+c},easeOutCirc:function(a,b,c,d,e){return d*Math.sqrt(1-(b=b/e-1)*b)+c},easeInOutCirc:function(a,b,c,d,e){if((b/=e/2)<1)return-d/2*(Math.sqrt(1-b*b)-1)+c;return d/2*(Math.sqrt(1-(b-=2)*b)+1)+c},easeInElastic:function(a,b,c,d,e){var f=1.70158;var g=0;var h=d;if(b==0)return c;if((b/=e)==1)return c+d;if(!g)g=e*.3;if(h<Math.abs(d)){h=d;var f=g/4}else var f=g/(2*Math.PI)*Math.asin(d/h);return-(h*Math.pow(2,10*(b-=1))*Math.sin((b*e-f)*2*Math.PI/g))+c},easeOutElastic:function(a,b,c,d,e){var f=1.70158;var g=0;var h=d;if(b==0)return c;if((b/=e)==1)return c+d;if(!g)g=e*.3;if(h<Math.abs(d)){h=d;var f=g/4}else var f=g/(2*Math.PI)*Math.asin(d/h);return h*Math.pow(2,-10*b)*Math.sin((b*e-f)*2*Math.PI/g)+d+c},easeInOutElastic:function(a,b,c,d,e){var f=1.70158;var g=0;var h=d;if(b==0)return c;if((b/=e/2)==2)return c+d;if(!g)g=e*.3*1.5;if(h<Math.abs(d)){h=d;var f=g/4}else var f=g/(2*Math.PI)*Math.asin(d/h);if(b<1)return-.5*h*Math.pow(2,10*(b-=1))*Math.sin((b*e-f)*2*Math.PI/g)+c;return h*Math.pow(2,-10*(b-=1))*Math.sin((b*e-f)*2*Math.PI/g)*.5+d+c},easeInBack:function(a,b,c,d,e,f){if(f==undefined)f=1.70158;return d*(b/=e)*b*((f+1)*b-f)+c},easeOutBack:function(a,b,c,d,e,f){if(f==undefined)f=1.70158;return d*((b=b/e-1)*b*((f+1)*b+f)+1)+c},easeInOutBack:function(a,b,c,d,e,f){if(f==undefined)f=1.70158;if((b/=e/2)<1)return d/2*b*b*(((f*=1.525)+1)*b-f)+c;return d/2*((b-=2)*b*(((f*=1.525)+1)*b+f)+2)+c},easeInBounce:function(a,b,c,d,e){return d-jQuery.easing.easeOutBounce(a,e-b,0,d,e)+c},easeOutBounce:function(a,b,c,d,e){if((b/=e)<1/2.75){return d*7.5625*b*b+c}else if(b<2/2.75){return d*(7.5625*(b-=1.5/2.75)*b+.75)+c}else if(b<2.5/2.75){return d*(7.5625*(b-=2.25/2.75)*b+.9375)+c}else{return d*(7.5625*(b-=2.625/2.75)*b+.984375)+c}},easeInOutBounce:function(a,b,c,d,e){if(b<e/2)return jQuery.easing.easeInBounce(a,b*2,0,d,e)*.5+c;return jQuery.easing.easeOutBounce(a,b*2-e,0,d,e)*.5+d*.5+c}})
 
/**
 * Copyright (c) 2007-2015 Ariel Flesler - aflesler<a>gmail<d>com | http://flesler.blogspot.com
 * Licensed under MIT
 * @author Ariel Flesler
 * @version 2.1.1
 */
;(function(f){"use strict";"function"===typeof define&&define.amd?define(["jquery"],f):"undefined"!==typeof module&&module.exports?module.exports=f(require("jquery")):f(jQuery)})(function($){"use strict";function n(a){return!a.nodeName||-1!==$.inArray(a.nodeName.toLowerCase(),["iframe","#document","html","body"])}function h(a){return $.isFunction(a)||$.isPlainObject(a)?a:{top:a,left:a}}var p=$.scrollTo=function(a,d,b){return $(window).scrollTo(a,d,b)};p.defaults={axis:"xy",duration:0,limit:!0};$.fn.scrollTo=function(a,d,b){"object"=== typeof d&&(b=d,d=0);"function"===typeof b&&(b={onAfter:b});"max"===a&&(a=9E9);b=$.extend({},p.defaults,b);d=d||b.duration;var u=b.queue&&1<b.axis.length;u&&(d/=2);b.offset=h(b.offset);b.over=h(b.over);return this.each(function(){function k(a){var k=$.extend({},b,{queue:!0,duration:d,complete:a&&function(){a.call(q,e,b)}});r.animate(f,k)}if(null!==a){var l=n(this),q=l?this.contentWindow||window:this,r=$(q),e=a,f={},t;switch(typeof e){case "number":case "string":if(/^([+-]=?)?\d+(\.\d+)?(px|%)?$/.test(e)){e= h(e);break}e=l?$(e):$(e,q);if(!e.length)return;case "object":if(e.is||e.style)t=(e=$(e)).offset()}var v=$.isFunction(b.offset)&&b.offset(q,e)||b.offset;$.each(b.axis.split(""),function(a,c){var d="x"===c?"Left":"Top",m=d.toLowerCase(),g="scroll"+d,h=r[g](),n=p.max(q,c);t?(f[g]=t[m]+(l?0:h-r.offset()[m]),b.margin&&(f[g]-=parseInt(e.css("margin"+d),10)||0,f[g]-=parseInt(e.css("border"+d+"Width"),10)||0),f[g]+=v[m]||0,b.over[m]&&(f[g]+=e["x"===c?"width":"height"]()*b.over[m])):(d=e[m],f[g]=d.slice&& "%"===d.slice(-1)?parseFloat(d)/100*n:d);b.limit&&/^\d+$/.test(f[g])&&(f[g]=0>=f[g]?0:Math.min(f[g],n));!a&&1<b.axis.length&&(h===f[g]?f={}:u&&(k(b.onAfterFirst),f={}))});k(b.onAfter)}})};p.max=function(a,d){var b="x"===d?"Width":"Height",h="scroll"+b;if(!n(a))return a[h]-$(a)[b.toLowerCase()]();var b="client"+b,k=a.ownerDocument||a.document,l=k.documentElement,k=k.body;return Math.max(l[h],k[h])-Math.min(l[b],k[b])};$.Tween.propHooks.scrollLeft=$.Tween.propHooks.scrollTop={get:function(a){return $(a.elem)[a.prop]()}, set:function(a){var d=this.get(a);if(a.options.interrupt&&a._last&&a._last!==d)return $(a.elem).stop();var b=Math.round(a.now);d!==b&&($(a.elem)[a.prop](b),a._last=this.get(a))}};return p});

/*!
 * Bootstrap YouTube Popup Player Plugin
 * http://lab.abhinayrathore.com/bootstrap-youtube/
 * https://github.com/abhinayrathore/Bootstrap-Youtube-Popup-Player-Plugin
 */
!function(o){function t(t){h.html(o.trim(t))}function e(o){b.html(o)}function u(){t(""),e("")}function a(o){c.css({width:o+2*m})}function i(o,t){return["//www.youtube.com/embed/",o,"?rel=0&showsearch=0&autohide=",t.autohide,"&autoplay=",t.autoplay,"&controls=",t.controls,"&fs=",t.fs,"&loop=",t.loop,"&showinfo=",t.showinfo,"&color=",t.color,"&theme=",t.theme,"&wmode=transparent"].join("")}function l(o,t,e){return['<iframe title="YouTube video player" width="',t,'" height="',e,'" ','style="margin:0; padding:0; box-sizing:border-box; border:0; -webkit-border-radius:5px; -moz-border-radius:5px; border-radius:5px; margin:',m-1,'px;" ','src="',o,'" frameborder="0" allowfullscreen seamless></iframe>'].join("")}function d(e){o.ajax({url:window.location.protocol+"//query.yahooapis.com/v1/public/yql",data:{q:"select * from json where url ='http://www.youtube.com/oembed?url=http://www.youtube.com/watch?v="+e+"&format=json'",format:"json"},dataType:"jsonp",success:function(o){o&&o.query&&o.query.results&&o.query.results.json&&t(o.query.results.json.title)}})}function r(o){var t=/^.*(youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=)([^#\&\?]*).*/,e=o.match(t);return e&&11==e[2].length?e[2]:!1}var n,s=null,c=null,h=null,b=null,m=5;n={init:function(n){if(n=o.extend({},o.fn.YouTubeModal.defaults,n),null==s){s=o('<div class="modal fade '+n.cssClass+'" id="YouTubeModal" role="dialog" aria-hidden="true">');var m='<div class="modal-dialog" id="YouTubeModalDialog"><div class="modal-content" id="YouTubeModalContent"><div class="modal-header"><button type="button" class="close" data-dismiss="modal">&times;</button><h4 class="modal-title" id="YouTubeModalTitle"></h4></div><div class="modal-body" id="YouTubeModalBody" style="padding:0;"></div></div></div>';s.html(m).hide().appendTo("body"),c=o("#YouTubeModalDialog"),h=o("#YouTubeModalTitle"),b=o("#YouTubeModalBody"),s.modal({show:!1}).on("hide.bs.modal",u)}return this.each(function(){var u=o(this),c=u.data("YouTube");c||(u.data("YouTube",{target:u}),o(u).bind("click.YouTubeModal",function(c){var h=n.youtubeId;""==o.trim(h)&&u.is("a")&&(h=r(u.attr("href"))),(""==o.trim(h)||h===!1)&&(h=u.attr(n.idAttribute));var b=o.trim(n.title);""==b&&(n.useYouTubeTitle?d(h):b=u.attr("title")),b&&t(b),a(n.width);var m=i(h,n),f=l(m,n.width,n.height);e(f),s.modal("show"),c.preventDefault()}))})},destroy:function(){return this.each(function(){o(this).unbind(".YouTubeModal").removeData("YouTube")})}},o.fn.YouTubeModal=function(t){return n[t]?n[t].apply(this,Array.prototype.slice.call(arguments,1)):"object"!=typeof t&&t?void o.error("Method "+t+" does not exist on Bootstrap.YouTubeModal"):n.init.apply(this,arguments)},o.fn.YouTubeModal.defaults={youtubeId:"",title:"",useYouTubeTitle:!0,idAttribute:"rel",cssClass:"YouTubeModal",width:640,height:480,autohide:2,autoplay:1,color:"red",controls:1,fs:1,loop:0,showinfo:0,theme:"light"}}(jQuery);


/*! Backstretch - v2.0.4 - 2013-06-19
* http://srobbin.com/jquery-plugins/backstretch/
* Copyright (c) 2013 Scott Robbin; Licensed MIT */
(function(a,d,p){a.fn.backstretch=function(c,b){(c===p||0===c.length)&&a.error("No images were supplied for Backstretch");0===a(d).scrollTop()&&d.scrollTo(0,0);return this.each(function(){var d=a(this),g=d.data("backstretch");if(g){if("string"==typeof c&&"function"==typeof g[c]){g[c](b);return}b=a.extend(g.options,b);g.destroy(!0)}g=new q(this,c,b);d.data("backstretch",g)})};a.backstretch=function(c,b){return a("body").backstretch(c,b).data("backstretch")};a.expr[":"].backstretch=function(c){return a(c).data("backstretch")!==p};a.fn.backstretch.defaults={centeredX:!0,centeredY:!0,duration:5E3,fade:0};var r={left:0,top:0,overflow:"hidden",margin:0,padding:0,height:"100%",width:"100%",zIndex:-999999},s={position:"absolute",display:"none",margin:0,padding:0,border:"none",width:"auto",height:"auto",maxHeight:"none",maxWidth:"none",zIndex:-999999},q=function(c,b,e){this.options=a.extend({},a.fn.backstretch.defaults,e||{});this.images=a.isArray(b)?b:[b];a.each(this.images,function(){a("<img />")[0].src=this});this.isBody=c===document.body;this.$container=a(c);this.$root=this.isBody?l?a(d):a(document):this.$container;c=this.$container.children(".backstretch").first();this.$wrap=c.length?c:a('<div class="backstretch"></div>').css(r).appendTo(this.$container);this.isBody||(c=this.$container.css("position"),b=this.$container.css("zIndex"),this.$container.css({position:"static"===c?"relative":c,zIndex:"auto"===b?0:b,background:"none"}),this.$wrap.css({zIndex:-999998}));this.$wrap.css({position:this.isBody&&l?"fixed":"absolute"});this.index=0;this.show(this.index);a(d).on("resize.backstretch",a.proxy(this.resize,this)).on("orientationchange.backstretch",a.proxy(function(){this.isBody&&0===d.pageYOffset&&(d.scrollTo(0,1),this.resize())},this))};q.prototype={resize:function(){try{var a={left:0,top:0},b=this.isBody?this.$root.width():this.$root.innerWidth(),e=b,g=this.isBody?d.innerHeight?d.innerHeight:this.$root.height():this.$root.innerHeight(),j=e/this.$img.data("ratio"),f;j>=g?(f=(j-g)/2,this.options.centeredY&&(a.top="-"+f+"px")):(j=g,e=j*this.$img.data("ratio"),f=(e-b)/2,this.options.centeredX&&(a.left="-"+f+"px"));this.$wrap.css({width:b,height:g}).find("img:not(.deleteable)").css({width:e,height:j}).css(a)}catch(h){}return this},show:function(c){if(!(Math.abs(c)>this.images.length-1)){var b=this,e=b.$wrap.find("img").addClass("deleteable"),d={relatedTarget:b.$container[0]};b.$container.trigger(a.Event("backstretch.before",d),[b,c]);this.index=c;clearInterval(b.interval);b.$img=a("<img />").css(s).bind("load",function(f){var h=this.width||a(f.target).width();f=this.height||a(f.target).height();a(this).data("ratio",h/f);a(this).fadeIn(b.options.speed||b.options.fade,function(){e.remove();b.paused||b.cycle();a(["after","show"]).each(function(){b.$container.trigger(a.Event("backstretch."+this,d),[b,c])})});b.resize()}).appendTo(b.$wrap);b.$img.attr("src",b.images[c]);return b}},next:function(){return this.show(this.index<this.images.length-1?this.index+1:0)},prev:function(){return this.show(0===this.index?this.images.length-1:this.index-1)},pause:function(){this.paused=!0;return this},resume:function(){this.paused=!1;this.next();return this},cycle:function(){1<this.images.length&&(clearInterval(this.interval),this.interval=setInterval(a.proxy(function(){this.paused||this.next()},this),this.options.duration));return this},destroy:function(c){a(d).off("resize.backstretch orientationchange.backstretch");clearInterval(this.interval);c||this.$wrap.remove();this.$container.removeData("backstretch")}};var l,f=navigator.userAgent,m=navigator.platform,e=f.match(/AppleWebKit\/([0-9]+)/),e=!!e&&e[1],h=f.match(/Fennec\/([0-9]+)/),h=!!h&&h[1],n=f.match(/Opera Mobi\/([0-9]+)/),t=!!n&&n[1],k=f.match(/MSIE ([0-9]+)/),k=!!k&&k[1];l=!((-1<m.indexOf("iPhone")||-1<m.indexOf("iPad")||-1<m.indexOf("iPod"))&&e&&534>e||d.operamini&&"[object OperaMini]"==={}.toString.call(d.operamini)||n&&7458>t||-1<f.indexOf("Android")&&e&&533>e||h&&6>h||"palmGetResource"in d&&e&&534>e||-1<f.indexOf("MeeGo")&&-1<f.indexOf("NokiaBrowser/8.5.0")||k&&6>=k)})(jQuery,window);

/**
* jquery.matchHeight-min.js master
* http://brm.io/jquery-match-height/
* License: MIT
*/
(function(c){var n=-1,f=-1,g=function(a){return parseFloat(a)||0},r=function(a){var b=null,d=[];c(a).each(function(){var a=c(this),k=a.offset().top-g(a.css("margin-top")),l=0<d.length?d[d.length-1]:null;null===l?d.push(a):1>=Math.floor(Math.abs(b-k))?d[d.length-1]=l.add(a):d.push(a);b=k});return d},p=function(a){var b={byRow:!0,property:"height",target:null,remove:!1};if("object"===typeof a)return c.extend(b,a);"boolean"===typeof a?b.byRow=a:"remove"===a&&(b.remove=!0);return b},b=c.fn.matchHeight=
function(a){a=p(a);if(a.remove){var e=this;this.css(a.property,"");c.each(b._groups,function(a,b){b.elements=b.elements.not(e)});return this}if(1>=this.length&&!a.target)return this;b._groups.push({elements:this,options:a});b._apply(this,a);return this};b._groups=[];b._throttle=80;b._maintainScroll=!1;b._beforeUpdate=null;b._afterUpdate=null;b._apply=function(a,e){var d=p(e),h=c(a),k=[h],l=c(window).scrollTop(),f=c("html").outerHeight(!0),m=h.parents().filter(":hidden");m.each(function(){var a=c(this);
a.data("style-cache",a.attr("style"))});m.css("display","block");d.byRow&&!d.target&&(h.each(function(){var a=c(this),b="inline-block"===a.css("display")?"inline-block":"block";a.data("style-cache",a.attr("style"));a.css({display:b,"padding-top":"0","padding-bottom":"0","margin-top":"0","margin-bottom":"0","border-top-width":"0","border-bottom-width":"0",height:"100px"})}),k=r(h),h.each(function(){var a=c(this);a.attr("style",a.data("style-cache")||"")}));c.each(k,function(a,b){var e=c(b),f=0;if(d.target)f=
d.target.outerHeight(!1);else{if(d.byRow&&1>=e.length){e.css(d.property,"");return}e.each(function(){var a=c(this),b={display:"inline-block"===a.css("display")?"inline-block":"block"};b[d.property]="";a.css(b);a.outerHeight(!1)>f&&(f=a.outerHeight(!1));a.css("display","")})}e.each(function(){var a=c(this),b=0;d.target&&a.is(d.target)||("border-box"!==a.css("box-sizing")&&(b+=g(a.css("border-top-width"))+g(a.css("border-bottom-width")),b+=g(a.css("padding-top"))+g(a.css("padding-bottom"))),a.css(d.property,
f-b))})});m.each(function(){var a=c(this);a.attr("style",a.data("style-cache")||null)});b._maintainScroll&&c(window).scrollTop(l/f*c("html").outerHeight(!0));return this};b._applyDataApi=function(){var a={};c("[data-match-height], [data-mh]").each(function(){var b=c(this),d=b.attr("data-mh")||b.attr("data-match-height");a[d]=d in a?a[d].add(b):b});c.each(a,function(){this.matchHeight(!0)})};var q=function(a){b._beforeUpdate&&b._beforeUpdate(a,b._groups);c.each(b._groups,function(){b._apply(this.elements,
this.options)});b._afterUpdate&&b._afterUpdate(a,b._groups)};b._update=function(a,e){if(e&&"resize"===e.type){var d=c(window).width();if(d===n)return;n=d}a?-1===f&&(f=setTimeout(function(){q(e);f=-1},b._throttle)):q(e)};c(b._applyDataApi);c(window).bind("load",function(a){b._update(!1,a)});c(window).bind("resize orientationchange",function(a){b._update(!0,a)})})(jQuery);

/* HTML5 Placeholder jQuery Plugin - v2.3.1
 * Copyright (c)2015 Mathias Bynens
 * 2015-12-16
 */
!function(a){"function"==typeof define&&define.amd?define(["jquery"],a):a("object"==typeof module&&module.exports?require("jquery"):jQuery)}(function(a){function b(b){var c={},d=/^jQuery\d+$/;return a.each(b.attributes,function(a,b){b.specified&&!d.test(b.name)&&(c[b.name]=b.value)}),c}function c(b,c){var d=this,f=a(this);if(d.value===f.attr(h?"placeholder-x":"placeholder")&&f.hasClass(n.customClass))if(d.value="",f.removeClass(n.customClass),f.data("placeholder-password")){if(f=f.hide().nextAll('input[type="password"]:first').show().attr("id",f.removeAttr("id").data("placeholder-id")),b===!0)return f[0].value=c,c;f.focus()}else d==e()&&d.select()}function d(d){var e,f=this,g=a(this),i=f.id;if(!d||"blur"!==d.type||!g.hasClass(n.customClass))if(""===f.value){if("password"===f.type){if(!g.data("placeholder-textinput")){try{e=g.clone().prop({type:"text"})}catch(j){e=a("<input>").attr(a.extend(b(this),{type:"text"}))}e.removeAttr("name").data({"placeholder-enabled":!0,"placeholder-password":g,"placeholder-id":i}).bind("focus.placeholder",c),g.data({"placeholder-textinput":e,"placeholder-id":i}).before(e)}f.value="",g=g.removeAttr("id").hide().prevAll('input[type="text"]:first').attr("id",g.data("placeholder-id")).show()}else{var k=g.data("placeholder-password");k&&(k[0].value="",g.attr("id",g.data("placeholder-id")).show().nextAll('input[type="password"]:last').hide().removeAttr("id"))}g.addClass(n.customClass),g[0].value=g.attr(h?"placeholder-x":"placeholder")}else g.removeClass(n.customClass)}function e(){try{return document.activeElement}catch(a){}}var f,g,h=!1,i="[object OperaMini]"===Object.prototype.toString.call(window.operamini),j="placeholder"in document.createElement("input")&&!i&&!h,k="placeholder"in document.createElement("textarea")&&!i&&!h,l=a.valHooks,m=a.propHooks,n={};j&&k?(g=a.fn.placeholder=function(){return this},g.input=!0,g.textarea=!0):(g=a.fn.placeholder=function(b){var e={customClass:"placeholder"};return n=a.extend({},e,b),this.filter((j?"textarea":":input")+"["+(h?"placeholder-x":"placeholder")+"]").not("."+n.customClass).not(":radio, :checkbox, [type=hidden]").bind({"focus.placeholder":c,"blur.placeholder":d}).data("placeholder-enabled",!0).trigger("blur.placeholder")},g.input=j,g.textarea=k,f={get:function(b){var c=a(b),d=c.data("placeholder-password");return d?d[0].value:c.data("placeholder-enabled")&&c.hasClass(n.customClass)?"":b.value},set:function(b,f){var g,h,i=a(b);return""!==f&&(g=i.data("placeholder-textinput"),h=i.data("placeholder-password"),g?(c.call(g[0],!0,f)||(b.value=f),g[0].value=f):h&&(c.call(b,!0,f)||(h[0].value=f),b.value=f)),i.data("placeholder-enabled")?(""===f?(b.value=f,b!=e()&&d.call(b)):(i.hasClass(n.customClass)&&c.call(b),b.value=f),i):(b.value=f,i)}},j||(l.input=f,m.value=f),k||(l.textarea=f,m.value=f),a(function(){a(document).delegate("form","submit.placeholder",function(){var b=a("."+n.customClass,this).each(function(){c.call(this,!0,"")});setTimeout(function(){b.each(d)},10)})}),a(window).bind("beforeunload.placeholder",function(){var b=!0;try{"javascript:void(0)"===document.activeElement.toString()&&(b=!1)}catch(c){}b&&a("."+n.customClass).each(function(){this.value=""})}))});

jQuery(function(){
    // Backstretch data attirbute
    jQuery('[data-bgimage]').each(function(idx, el) {
		var $el = jQuery(el),
			src = $el.data('bgimage');
		if (src) {
			$el.backstretch(src);
		}
	});
	// Add class to html if you are using device
	if( /Android|webOS|iPhone|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ) {
		jQuery('html').addClass('device');
	}
	// Add active trail to student tab on front page
	var bodyCheck = jQuery('body');
	if (bodyCheck.hasClass('front') || bodyCheck.hasClass('active-menu')){
		jQuery('.main-nav > .menu-block-wrapper > .menu > li.first').addClass('active-trail');
	};
	// Mobile Nav
	if (jQuery(window).width() < 768){
		// Slides nav to left revealing child pages
		jQuery(".main-nav > .menu-block-wrapper > .menu > li > a").click(function(event) {
			jQuery(this).parents().addClass('slid');
			jQuery('.main-nav > .menu-block-wrapper > .menu').animate({
				left: "-=100%"
			});
			return false;
		});
		// Adds return to menu link
		jQuery('<li class="back"><a href="#" class="return"><span class="title">Main Menu</span></a></li>').prependTo('.main-nav > .menu-block-wrapper > .menu > li > ul');
		// Slides nav to from left revealing parent pages 
		jQuery('.main-nav .return').click(function(event) {
			jQuery('.main-nav > .menu-block-wrapper > .menu').animate({
				left: "+=100%"
			}, 500, function () {
				jQuery('.main-nav > .menu-block-wrapper > .menu > li').removeClass('slid');
			});
			return false;
		});
		// Add class to header to change color when menu is opened
		jQuery(".navbar-toggle").click(function(event) {
			jQuery('header .bottom').toggleClass('opened');
			jQuery('.main-nav > .menu-block-wrapper > .menu').css('left','0');
		});	
	};
	// Menu active state - Sets children of active menu item to display block
	var activeItem = jQuery('.main-nav > .menu-block-wrapper > .menu > li.active-trail');
	jQuery('.main-nav > .menu-block-wrapper > .menu > li:not(.active-trail, .last)').hover(
		function(){ activeItem.addClass('other-hovered') },
		function(){ activeItem.removeClass('other-hovered') }
	);
	// Add span around text in footer submit button so it can be hidden
	jQuery("footer .form-submit").wrapInner('<span></span>');
	// Search Open
	jQuery('.main-nav > .menu-block-wrapper > .menu > li.last a').click(function() {
		jQuery(this).parents().toggleClass('active-trail');
		jQuery('.search-bar').slideToggle();
		return false;
	});
	//Remove links from a with class nolink
	jQuery('ul.nav').find('a.nolink').removeAttr('href');
	// Search Close
	jQuery('.search-close').click(function() {
		jQuery('.main-nav > .menu-block-wrapper > .menu > li.last').removeClass('active-trail');
		jQuery('.search-bar').slideUp();
		return false;
	});
	// Homepage CTA SlideToggle on mobile
	if (jQuery(window).width() < 768){
		jQuery('.cta-wrap').click(function() {
			jQuery(this).parent().siblings().find('.cta-box').removeClass('opened');
			jQuery(this).children('.cta-box').toggleClass('opened');
		});
	};
	setTimeout(
		function() {
		// Career Tab / Carousel
		var careertabs = jQuery('.view-career-teaser-on-homepage .nav-tabs');
		var owl = careertabs.owlCarousel({
			margin:60,
			loop:true,
			autoWidth:true,
			activeClass: 'showing',
			nav:true,
			items:6,
			startPosition: 0,
			stageElement: 'ul',
			itemElement: 'li',
			navText: ['&nbsp;','&nbsp;']
		});
		careertabs.find('.owl-stage').find('.showing:first').addClass('active');
	}, 500);
    // Equal Heights
    jQuery('.event-col').matchHeight();
    jQuery('.intro-col').matchHeight();
  //  jQuery('.interior-wrap .main-col').matchHeight();
	//Form validations
	jQuery('#cc_signup_form_1').validate( {rules: { cc_email_1 : {required: true, email : true }  },
		errorPlacement:function(error, element) {error.appendTo(element.parents('form'))},
		errorClass: "alert alert-block alert-danger pull-left"
	});
	jQuery('#edit-cc-email-1').attr('placeholder','Email Address').keyup( function(e) { if (e.keyCode==13) {jQuery(e.target).parents('form').find('.form-submit').mousedown()}});
	// Youtube Modal Window
	jQuery(".youtube").YouTubeModal({autoplay:0});
	// Mobile Tab/Collapse Functionality
	jQuery('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
		var activeText = jQuery('.faq-collapse .active a').text();
		jQuery('.faq-toggle .toggle-text').text(activeText);
		jQuery('.faq-collapse').collapse('hide')
		//alert(activeText);
	});
	// Bootstrap Select
	jQuery('.selectpicker').selectpicker();
	// Bootstrap Checkbox
	jQuery('input[type="checkbox"]').checkbox({
		buttonStyle: 'btn-check',	
	});
	// IE9 Placeholder fix
	jQuery('input, textarea').placeholder();

	//Controls for contact us page views ajax
	jQuery('.selectpicker.level1').on('changed.bs.select', function(e) {
		jQuery('.view-query-response').slideUp();
		jQuery('.response-button').addClass('hidden');
		var parentid = jQuery(e.target).val();
		jQuery('.form-group.level2')
			.removeClass('hidden')
			.find('.bootstrap-select.level2')
			.addClass('hidden')
			.parents('.form-group.level2'
		).find('.parent-'+parentid).removeClass('hidden');
	});
	jQuery('.selectpicker.level2').on('changed.bs.select', function(e) {
		jQuery('.view-query-response').show().filter('div').html('<span class="spinner"><i class="fa fa-spinner fa-spin"></i></span>');
		jQuery('.response-button').removeClass('hidden');
		var termid = jQuery(e.target).val();
		Drupal.settings.views.ajaxViews[0].view_args = termid;
		var data = {};
// Add view settings to the data.
		for (var key in Drupal.settings.views.ajaxViews[0]) {
			data[key] = Drupal.settings.views.ajaxViews[0][key];
		}
		jQuery.ajax({
			url: Drupal.settings.views.ajax_path,
			type: 'GET',
			data: data,
			success: function(response) {
				console.log(response[1].data);
				var viewDiv = '#faq-tab-view-query-response';
				jQuery(viewDiv).html(response[1].data);
				// Call all callbacks.
				if (response.__callbacks) {
					jQuery.each(response.__callbacks, function(i, callback) {
						eval(callback)(viewDiv, response);
					});
				}
			},
			error: function(xhr) {
				jQuery(viewDiv).html('<p id="artist-load-error">View could not be loaded. </p>');
			},
			dataType: 'json'
		});
	});

    //Kludgey fix for webform isssue
	$webform = jQuery('#questionModal .webform-conditional-hidden');
	$webform.find('button').removeClass('disabled');
	$webform.find('.btn-group').removeClass('disabled');
	//Patches for Events filter
	Drupal.behaviors.betterExposedFilters = {
		attach: addResponsiveClassesAndActions
	};

	function addResponsiveClassesAndActions(context) {
        $context = jQuery(context);
        if ($context.has('div.events-filter').length) {
            $context.find('input[type="checkbox"]').checkbox({buttonStyle: 'btn-check'});
            $context.find('.bef-checkboxes').addClass('row');
            $context.find('.form-type-bef-checkbox').addClass('col-md-6 col-sm-6');
            //Sync between views filters+pagination
            jQuery('#listView').find('.umd-previous>a').one('click', function (e) {
                jQuery('#calView').find('.umd-previous>a').click();
            });
            jQuery('#listView').find('.umd-next>a').one('click', function (e) {
                jQuery('#calView').find('.umd-next>a').click();
            });
            jQuery('#calView').find('.umd-previous>a').one('click', function (e) {
                jQuery('#listView').find('.umd-previous>a').click();
            });
            jQuery('#calView').find('.umd-next>a').one('click', function (e) {
                jQuery('#listView').find('.umd-next>a').click();
            });
            jQuery('.listing-filter-block').find('.form-type-bef-checkbox input').on('click', function (e) {
                var category = jQuery(e.target).val();
                jQuery('.calendar-filter-block').find('.form-item-edit-field-event-type-tid-' + category + ' input').click();
            });
            jQuery('.calendar-filter-block').find('.form-type-bef-checkbox input').on('click', function (e) {
                var category = jQuery(e.target).val();
                jQuery('.listing-filter-block').find('.form-item-edit-field-event-type-tid-' + category + ' input').click();
            });
            //Add More expander
            jQuery('td.single-day').not('.empty').not('.no-entry').each(function (index) {
                $this = jQuery(this);
                $items = $this.find('.item');
                if ($items.length > 2) {
                    $items.each(function (i) {
                        if (i > 1) {
                            jQuery(this).hide();
                        }
                    });
                    var hiddenItems = $items.length - 2;
                    var linkstring = '<a class="showMoreEvents" href="#">+ ' + hiddenItems + ' More</a>';
                    $this.append(linkstring);
                    $this.on('click', 'a.showMoreEvents', function (e) {
                        e.preventDefault();
                        jQuery(e.target).hide().parents('td').find('.item').slideDown();
                    })
                }
            });
        }
	}
	addResponsiveClassesAndActions('.views-exposed-form');


	// Event Details Carousel
	jQuery('#eventGallery').owlCarousel({
		loop:false,
		margin:40,
		nav:true,
		rewindNav:false,
		dots:false,
		navText: ['&nbsp;','&nbsp;'],
		navClass: ['owl-prev disabled','owl-next'],
		responsive:{
			0:{
				items:1
			},
			480:{
				items:2
			},
			768:{
				items:3
			}
		}
	});
	//jQuery("#eventGallery").on('initialized.owl.carousel changed.owl.carousel refreshed.owl.carousel', function (event) {
	//	if (!event.namespace) return;
	//	var carousel = event.relatedTarget,
	//		element = event.target,
	//		current = carousel.current();
	//	jQuery('.owl-next', element).toggleClass('disabled', current === carousel.maximum());
	//	jQuery('.owl-prev', element).toggleClass('disabled', current === carousel.minimum());
	//});
	// Events Gallery Modal Function 
	var html;     
	jQuery('.event-photos .owl-item img').on('click',function(){
		var src = jQuery(this).attr('src');
		var title = jQuery(this).attr('title');
		var img = '<img src="' + src + '" class="img-responsive"/><div class="caption"><div class="inner">' + title + '</div></div>';
		
		//start of new code new code
		var index = jQuery(this).parents('.owl-item').index();   
		
		html = '';
		html += img;                
		html += '<div class="modal-controls">';
		html += '<a class="controls next" href="'+ (index+2) + '">&nbsp;</a>';
		html += '<a class="controls prev" href="' + (index) + '">&nbsp;</a>';
		html += '</div>';
		
		jQuery('#galleryModal').modal();
   });
   jQuery('#galleryModal').on('shown.bs.modal', function(){
		jQuery('#galleryModal .modal-body').html(html);
		//new code
		jQuery('a.controls').trigger('click');
	});
	jQuery('#galleryModal').on('hidden.bs.modal', function(){
		jQuery('#galleryModal .modal-body').html('');
	});
});
// Events Gallery Next/Prev Function
jQuery(document).on('click', 'a.controls', function(){
	var index = jQuery(this).attr('href');
	var src = jQuery('.view-event-photos-gallery .owl-item:nth-child('+ index +') img').attr('src');
	var title = jQuery('.view-event-photos-gallery .owl-item:nth-child('+ index +') img').attr('title');            
	
	jQuery('.modal-body img').attr('src', src);
	jQuery('.modal-body .caption .inner').html(title);
	
	var newPrevIndex = parseInt(index) - 1; 
	var newNextIndex = parseInt(newPrevIndex) + 2; 
	
	if(jQuery(this).hasClass('prev')){               
		jQuery(this).attr('href', newPrevIndex); 
		jQuery('a.next').attr('href', newNextIndex);
	}else{
		jQuery(this).attr('href', newNextIndex); 
		jQuery('a.prev').attr('href', newPrevIndex);
	}
	
	var total = jQuery('.view-event-photos-gallery .owl-item').length + 1; 
	//hide next button
	if(total === newNextIndex){
		jQuery('a.next').hide();
	}else{
		jQuery('a.next').show();
	}            
	//hide previous button
	if(newPrevIndex === 0){
		jQuery('a.prev').hide();
	}else{
		jQuery('a.prev').show();
	}
	return false;
});

(function ($) {
	Drupal.behaviors.myBehavior = {
		attach: function (context, settings) {
			jQuery(function(){
				$(".pagination .next a, .pagination .pager-last a, .pagination .prev a, .pagination .pager-first a").wrapInner("<span></span>");
			});
		}
	};
}(jQuery));
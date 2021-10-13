(function($) {

  Drupal.behaviors.selective_tweets_async_load = {
    attach: function(context, settings) {
      // Apply theme settings to Tweets.
      var selective_tweets = Drupal.settings.selective_tweets;

      $('.selective-tweets-async-load').once('async-load', function() {
        var container = $(this).parent();
        var throbber = $(this).find('.ajax-progress');
        var id = $(this).attr('id');
        // Get block id.
        var delta = id.replace('selective-tweets-block-', '');

        if (typeof selective_tweets[delta] !== 'undefined') {
          tweet_settings = selective_tweets[delta];

          // Load block content.
          $(this).load(tweet_settings['initial_load_url'], function () {
            throbber.remove();
            Drupal.attachBehaviors(container);
          });
        }
        else {
          // Something went wrong, we don't have any settings of this block.
          throbber.remove();
        }
      });
    }
  };

  // An ajax command to trigger attachBehaviors.
  Drupal.ajax.prototype.commands.selective_tweets_attach_behaviors = function(ajax, response, status) {
    Drupal.attachBehaviors($(response.container));
  }

})(jQuery);

# Football-World-Cup-Score-Board-
Test Exercise

1. The StartTime property is used for secondary sorting (if scores sum is equal) for the sake of universality and expandability.
2. Equal method for Game class ignores StartTime for the sake of testing (to no implement separate Comparer for testing).
3. List<T> is used to store Games. No need for Dictionary as scoreboards usually do not contain a lot of games simultaneously.

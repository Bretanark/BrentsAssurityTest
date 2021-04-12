# BrentsAssurityTest
Brent Clark's test for Assurity

This project demonstrates Brent's programming of a API automation test in NUnit.

## Background
This is a rather bare-bones test, assuming full stack tracing on failures from a debug build to be used in conjunction with the original source code.  As such, a failure will include the line number of the failure and error description, so descriptive messages are not important, nor is defensive coding in case of invalid responses.  This depends very much upon requirements not specified in the given task and coding styles.
Normally I'd have a separate class to manage Http interaction, but since it's used once, this is unnecessary overhead.  In an enterprise setting, I'd have concrete classes to deserialize to for better code reuse and intellisense support.  Again, for a single test, that'd be overkill.

## Status
The test currently fails due to the test data not meeting expectations.  I assume a Test Driven Development approach is being applied such that when the "developer" fixes the API, the test will pass.

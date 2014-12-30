﻿// Copyright (c) Microsoft Open Technologies, Inc.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

namespace Roslyn.Diagnostics.Analyzers
{
    internal static class RoslynDiagnosticIds
    {
        public const string UseEmptyEnumerableRuleId = "RS0001";
        public const string UseSingletonEnumerableRuleId = "RS0002";
        public const string DirectlyAwaitingTaskAnalyzerRuleId = "RS0003";
        public const string UseSiteDiagnosticsCheckerRuleId = "RS0004";
        public const string DontUseCodeActionCreateRuleId = "RS0005";
        public const string MixedVersionsOfMefAttributesRuleId = "RS0006";
        public const string UseArrayEmptyRuleId = "RS0007";
        public const string ImplementIEquatableRuleId = "RS0008";
        public const string OverrideObjectEqualsRuleId = "RS0009";
        public const string MissingSharedAttributeRuleId = "RS0010";
        public const string DoNotUseVerbatimCrefsRuleId = "RS0010";
        public const string CancellationTokenMustBeLastRuleId = "RS0011";
        public const string DoNotCallToImmutableArrayRuleId = "RS0012";
        public const string DoNotAccessDiagnosticDescriptorRuleId = "RS0013";
        public const string DoNotCallLinqOnIndexable = "RS0014";
        public const string ConsumePreserveSigRuleId = "RS0015";

        // Meta analyzers: Analyzers validating implementation of DiagnosticAnalyzers.
        // TODO: Refactor these into a separate project as these are not specific to Roslyn.sln
        public const string MissingDiagnosticAnalyzerAttributeRuleId = "RS1001";
        public const string MissingKindArgumentToRegisterActionRuleId = "RS1002";
        public const string UnsupportedSymbolKindArgumentRuleId = "RS1003";
        public const string ExpensiveCompilationEndActionRuleId = "RS1004";
        public const string AddLanguageSupportToAnalyzerRuleId = "RS1005";
        public const string InvalidReportDiagnosticRuleId = "RS1006";
    }
}
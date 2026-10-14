// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

/**
 * @name Code comment
 * @description Code has no comments. A comment needs a legal marker, a functional directive, an https link that proves it, or it documents the public API.
 * @kind problem
 * @problem.severity error
 * @id cs/no-code-comments
 */

import csharp

predicate proven(CommentLine line) {
  line.getText().regexpMatch("(?s).*(https://|SPDX-|REUSE-Ignore).*")
  or
  exists(CommentLine next |
    next.getLocation().getFile() = line.getLocation().getFile() and
    next.getLocation().getStartLine() = line.getLocation().getEndLine() + 1 and
    proven(next)
  )
}

predicate directive(CommentLine line) {
  line.getText().regexpMatch("(?s)\\s*(ReSharper (disable|restore)|<inheritdoc\\b|@formatter:).*")
}

predicate inShippedCode(CommentLine line) {
  not line.getLocation().getFile().getRelativePath().regexpMatch(".*\\.Tests/.*")
}

predicate documentsPublicApi(XmlCommentLine line) {
  inShippedCode(line) and
  line.getParent().getElement().(Modifiable).isEffectivelyPublic()
}

predicate inheritedByPublicApi(Member member) {
  exists(XmlCommentLine reference |
    documentsPublicApi(reference) and
    reference
        .getText()
        .regexpMatch(".*<inheritdoc\\s+cref=\"([^\"]*\\.)?" + member.getDeclaringType().getUndecoratedName() +
            "(\\{[^\"]*\\})?\\." + member.getName() + "\".*")
  )
}

predicate documentsInheritedApi(XmlCommentLine line) {
  inShippedCode(line) and inheritedByPublicApi(line.getParent().getElement())
}

from CommentLine line
where
  exists(line.getLocation().getFile().getRelativePath()) and
  not line.getLocation().getFile().getRelativePath().regexpMatch("(.*/)?(bin|obj)/.*") and
  not proven(line) and
  not directive(line) and
  not documentsPublicApi(line) and
  not documentsInheritedApi(line)
select line, "Code has no comments. Put the meaning in names, types and tests."

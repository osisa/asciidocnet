package org.asciidoctor.syntaxhighlighter

import org.asciidoctor.Asciidoctor
import org.asciidoctor.AttributesBuilder
import org.asciidoctor.OptionsBuilder
import org.asciidoctor.SafeMode
import org.jboss.arquillian.spock.ArquillianSputnik
import org.jboss.arquillian.test.api.ArquillianResource
import org.junit.runner.RunWith
import spock.lang.Ignore
import spock.lang.Specification

import static junit.framework.Assert.assertEquals

@RunWith(ArquillianSputnik)
class WhenACoderayAdapterIsImplementedInGroovy extends Specification {

  public static final String NAME_SYNTAXHIGHLIGHTER = 'coderay4J'

  @ArquillianResource
  private Asciidoctor asciidoctor

  @Ignore('until the latest release also puts the link to the CSS into the header')
  def 'should highlight with coderay'() {

    given:
    def doc = '''= Test Document
:nofooter:

[source,java]
----
System.out.println("Hello World"); // <1>
----

[source,go,linenums]
----
func main() {
  fmt.Println("Hello World") // <1>
}
----
'''

    asciidoctor.syntaxHighlighterRegistry().register(CoderayHighlighter, NAME_SYNTAXHIGHLIGHTER)

    when:
    String htmlJava = asciidoctor.convert(doc, OptionsBuilder.options()
            .safe(SafeMode.UNSAFE)
            .headerFooter(true)
            .attributes(AttributesBuilder.attributes()
                .sourceHighlighter(NAME_SYNTAXHIGHLIGHTER)
                .linkCss(true)))

    String htmlRuby = asciidoctor.convert(doc, OptionsBuilder.options()
            .safe(SafeMode.UNSAFE)
            .headerFooter(true)
            .attributes(AttributesBuilder.attributes()
                .sourceHighlighter('coderay')
                .linkCss(true)))

    then:
    // Cannot use `htmlRuby == htmlJava` because it fails with OOM
    assertEquals(htmlRuby, htmlJava)
  }
}

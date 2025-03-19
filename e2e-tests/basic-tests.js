import { Selector } from 'testcafe';

fixture("Calculator E2E tests")
    .page('http://79.76.48.213:3000');

const getButton = (label) => Selector("button").withText(label);
const getDisplayText = () => Selector(".calc-display").innerText;
const getMemoryItem = (line) => Selector(".memory-box ul li").nth(line).innerText;

test("Validate calculator ui showing", async t => {
    await t
        .expect(Selector(".home-title").innerText).eql("Choose from these two options:")
        .click(getButton("Simple Calculator")) 
        .expect(getDisplayText()).eql("0");
});

test("Validate calculator input", async t => {
    await t
        .click(getButton("Simple Calculator"))
        .click(getButton("1"))
        .click(getButton("+"))
        .click(getButton("2"))
        .click(getButton("="))
        .expect(getDisplayText()).eql("3");
});

test("Validate calculator memory", async t => {
    await t
        .click(getButton("Simple Calculator"))
        .click(getButton("5"))
        .click(getButton("+"))
        .click(getButton("5"))
        .click(getButton("="))
        .expect(getDisplayText()).eql("10")
        .expect(getMemoryItem(0)).eql("5+5 = 10");
});
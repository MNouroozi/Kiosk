// کلیدهای فارسی + اعداد + علائم
const persianKeys = [
    'ض', 'ص', 'ث', 'ق', 'ف', 'غ', 'ع', 'ه', 'خ', 'ح', 'ج', 'چ',
    'ش', 'س', 'ی', 'ب', 'ل', 'ا', 'ت', 'ن', 'م', 'ک', 'گ',
    'ظ', 'ط', 'ز', 'ر', 'ذ', 'د', 'پ', 'و', 'ژ',
    '1', '2', '3', '4', '5', '6', '7', '8', '9', '0',
    '.', '،', '؟', '/', '-', '_', '@'
];

let activeInput = null;

const keyboardContainer = document.getElementById("virtualKeyboard");
const keyboardKeys = keyboardContainer.querySelector(".keyboard-keys");

// ساخت کلیدها
persianKeys.forEach(key => {
    const btn = document.createElement("button");
    btn.className = "key-glass";
    btn.textContent = key;
    btn.dataset.key = key;
    keyboardKeys.appendChild(btn);
});

// اتصال کیبورد به یک input
function attachKeyboard(inputId) {
    const input = document.getElementById(inputId);
    if (!input) return;

    input.addEventListener("focus", () => {
        activeInput = input;
        keyboardContainer.style.display = "block";
    });
}

// رویداد کلیک کلیدها
keyboardContainer.addEventListener("click", (e) => {
    if (!activeInput) return;
    if (!e.target.classList.contains("key-glass")) return;

    const key = e.target.dataset.key;

    if (key === "space") {
        activeInput.value += " ";
    } else if (key === "backspace") {
        activeInput.value = activeInput.value.slice(0, -1);
    } else if (key === "enter") {
        activeInput.form?.submit(); // فرم رو ارسال می‌کنه
    } else if (key === "close") {
        keyboardContainer.style.display = "none";
        activeInput = null;
    } else {
        activeInput.value += key;
    }
});

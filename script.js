const labels = document.querySelectorAll(".form-control Label");

labels.forEach((Label) => {
  Label.innerHTML = Label.innerText
    .split("")
    .map(
      (letter, idx) =>
        `<asp:Label style="transition-delay:${idx * 30}ms">${letter}</asp:Label>`
    )
    .join("");
});
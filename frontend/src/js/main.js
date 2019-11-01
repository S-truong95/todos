import Header from "./components/Header";
import Footer from "./components/Footer";
import Todos from "./components/Todos";
import apiActions from "./api/apiActions";
import Home from "./components/Home";

export default () =>{
    pageBuild(); 
};

function pageBuild(){
    header();
    footer();
    navHome();
    navTodos();
}

function header(){
    const header = document.getElementById("header");
    header.innerHTML = Header();
}

function footer(){
    const footer = document.getElementById("footer");
    footer.innerHTML = Footer();
}

function navHome(){
    const homeButton = document.querySelector(".nav_home")
    homeButton.addEventListener("click", function(){
        document.querySelector("#app").innerHTML = Home();
    })
}

function navTodos(){
    const toDosButton = document.querySelector(".nav_toDos");
    
    toDosButton.addEventListener("click", function(){
        apiActions.getRequest("https://localhost:44385/api/todos", toDos => {
            document.querySelector("#app").innerHTML = Todos(toDos);
        });
    });

    const app = document.querySelector("#app");
    app.addEventListener("click", function(){
        if(event.target.classList.contains("add-toDo__submit")) {
            const toDo = event.target.parentElement.querySelector(
                ".add-toDo__toDoName"
            ).value;

            console.log(toDo);
            apiActions.postRequest("https://localhost:44385/api/todos",
            toDo,
            toDos =>{
                console.log(toDos);
                document.querySelector("#app").innerHTML = Todos(toDos)
            })
        }
    })


}

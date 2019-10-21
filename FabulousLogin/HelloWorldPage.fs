namespace FabulousLogin

open System.Diagnostics
open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.LiveUpdate
open Xamarin.Forms

module HelloWorldPage = 
    type Model = string

    type Msg = 
        | UpdateMessage of string
        | LoggedOut

    let initModel = ""

    let init () = 
        initModel, Cmd.ofMsg(UpdateMessage "World!")

    let update msg model =
        match msg with
        | UpdateMessage s -> sprintf "Hello %s" s, Cmd.none
        | LoggedOut -> model, Cmd.none

    let view (model: Model) dispatch =
        View.ContentPage(
            content = View.StackLayout(
                padding = 20.0,
                verticalOptions = LayoutOptions.Center,
                children = [
                    View.Label(
                        text = model,
                        horizontalOptions = LayoutOptions.Center,
                        widthRequest = 200.0,
                        horizontalTextAlignment=TextAlignment.Center
                    )
                    View.Button(
                        text = "Logout",
                        backgroundColor = Color.CadetBlue,
                        textColor = Color.White,
                        horizontalOptions = LayoutOptions.Center,
                        command = (fun () -> dispatch LoggedOut)
                    )
                ]
            )
        )

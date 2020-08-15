<template>
<v-layout align-start>
    <v-flex>
        <v-toolbar flat color="white">
            <v-toolbar-title>Posición Trabajo</v-toolbar-title>
            <v-divider class="mx-2" inset vertical></v-divider>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" text @click="newItem">Nuevo</v-btn>
        </v-toolbar>
        <v-data-table dense :headers="dataTables.posicionTrabajo.headers" :items="posiciones" item-key="posicionTrabajoId">
            <template v-slot:items="props">
                <tr>
                    <td class="text-xs-left">{{ props.item.posicionTrabajoId }}
                    </td>
                    <td class="text-xs-left">{{ props.item.nombre }}
                    </td>
                </tr>
            </template>
        </v-data-table>

        <v-row justify="center">
            <v-dialog v-model="dialog" persistent max-width="600px">
                <v-card>
                    <v-card-title>
                        <span class="headline">Nueva Posición Trabajo</span>
                    </v-card-title>
                    <v-card-text>
                        <v-container>
                            <v-row>
                                <v-col cols="12" sm="12" md="12">
                                    <v-text-field label="Nombre*" v-model="nombre" required></v-text-field>
                                </v-col>
                            </v-row>
                        </v-container>
                        <small>*indicates required field</small>
                    </v-card-text>
                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn color="blue darken-1" text @click="dialog = false">Close</v-btn>
                        <v-btn color="blue darken-1" text @click="save">Save</v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
        </v-row>
    </v-flex>
</v-layout>
</template>

<script>
import axios from "axios";

export default {
    data() {
        return {
            posiciones: [],
            dialog: false,
            nombre: null,
            dataTables: {
                posicionTrabajo: {
                    headers: [{
                            text: "id",
                            value: "posicionTrabajoId",
                            sortable: false,
                            align: "left"
                        },
                        {
                            text: "Nombre",
                            value: "nombre",
                            sortable: false,
                            align: "left"
                        }
                    ]
                }
            },
        };
    },
    mounted() {
        this.getData();
    },
    methods: {
        newItem() {
            this.dialog = true;
            this.nombre = "";
        },
        save() {

            if(this.nombre == ""){return;}

            axios({
                method: "POST",
                url: "http://localhost:58365/api/Posicion-Trabajo/Crear",
                data: {
                    Nombre: this.nombre
                }
            }).then(result => {
                this.getData();
                this.dialog = false;
            }, error => {
                console.error(error);
            });
        },
        getData() {
            axios({
                method: "GET",
                url: "http://localhost:58365/api/Posicion-Trabajo/Listar"
            }).then(result => {               
                this.posiciones = result.data;
            }, error => {
                console.error(error);
            });
        }
    }
}
</script>

<style lang="scss" scoped>

</style>

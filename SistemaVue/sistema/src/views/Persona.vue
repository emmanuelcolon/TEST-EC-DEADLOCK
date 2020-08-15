<template>
<v-layout align-start>
    <v-flex>
        <v-toolbar flat color="white">
            <v-toolbar-title>Persona</v-toolbar-title>
            <v-divider class="mx-2" inset vertical></v-divider>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" text @click="newItem">Nuevo</v-btn>
        </v-toolbar>
        <v-data-table dense :headers="dataTables.persona.headers" :items="personas" item-key="personaId">
            <template v-slot:items="props">
                <tr>
                    <td class="text-xs-left">{{ props.item.personaId }}
                    </td>
                    <td class="text-xs-left">{{ props.item.nombreCompleto }}
                    </td>
                    <td class="text-xs-left">{{ props.item.nombrePosicionTrabajo }}
                    </td>
                </tr>
            </template>
        </v-data-table>

        <v-row justify="center">
            <v-dialog v-model="dialog" persistent max-width="600px">
                <v-card>
                    <v-card-title>
                        <span class="headline">Nueva Persona</span>
                    </v-card-title>
                    <v-card-text>
                        <v-container>
                            <v-row>
                                <v-col cols="12" sm="12" md="12">
                                    <v-text-field label="Nombre*" v-model="nombreCompleto" required></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="12" md="12">
                                    <v-autocomplete v-model="posicionTrabajoId" :items="posiciones" item-text="nombre" item-value="posicionTrabajoId" label="Posición Trabajo*" color="secondary"></v-autocomplete>

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
            personas: [],
            posiciones: [],
            dialog: false,
            nombreCompleto: null,
            posicionTrabajoId: null,
            dataTables: {
                persona: {
                    headers: [{
                            text: "id",
                            value: "personaId",
                            sortable: false,
                            align: "left"
                        },
                        {
                            text: "Nombre Completo",
                            value: "nombreCompleto",
                            sortable: false,
                            align: "left"
                        },
                        {
                            text: "Posición de Trabajo",
                            value: "nombrePosicionTrabajo",
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
        this.getPosiciones();
    },
    methods: {
        newItem() {
            this.dialog = true;
            this.nombreCompleto = "";
        },
        save() {

            if (this.nombreCompleto == "") { return; }

            axios({
                method: "POST",
                url: "http://localhost:58365/api/Persona/Crear",
                data: {
                    NombreCompleto: this.nombreCompleto,
                    PosicionTrabajoId: this.posicionTrabajoId
                }
            }).then(result => {
                this.getData();
                this.dialog = false;
            }, error => {
                console.error(error);
            });
        },
        getData() {
            axios({ method: "GET", "url": "http://localhost:58365/api/Persona/Listar" }).then(result => {
                this.personas = result.data;
            }, error => {
                console.error(error);
            });
        },
        getPosiciones() {
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

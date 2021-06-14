<template>
  <div class="q-pa-md row items-start q-gutter-md">
    <div class="cards">
      <div v-if="!this.admin" class="hidden1">
        <q-card>
          <div class="firstCard">
            <q-img src="../../public/pluss.png" />
          </div>
        </q-card>
      </div>
      <div v-else class="row items-center addCard">
        <div class="col-12 q-pa-xl">
          <div
            class="col-12 q-pa-md"
            style="display: flex; flex-direction: row; justify-content: center"
          >
            <div class="firstCard" @click="handleClickPlus">
              <q-img src="../../public/pluss.png" />
            </div>
          </div>
          <div class="col-4 q-tm-md">
            <label class="text-h6 name">Dodajte novo jelo</label>
          </div>

          <div class="Cup q-pt-xl">
            <q-img src="../../public/solja.png" />
          </div>
        </div>
      </div>
      <q-card
        v-for="(dish, index) in dishesForView.slice(
          (currentPage - 1) * dishesPerPage,
          currentPage * dishesPerPage
        )"
        :key="index"
        class="my-card"
      >
        <div class="col-4">
          <q-img :src="dish.image" style="height: 200px; width: 100%" />

          <div class="q-pa-md">
            <div class="col text-h6 name ellipsis">
              {{ dish.name }}
            </div>
          </div>
          <div class="row q-pa-md">
            <q-rating
              v-model="dish.averageRating"
              size="2em"
              :max="5"
              color="yellow"
              readonly
            />
            <div class="q-mx-sm"></div>
            <div class="text-h6 text-yellow justify-content:flex-end">
              {{ dish.averageRating }}
            </div>
          </div>

          <div
            style="
              text-overflow: ellipsis;
              white-space: nowrap;
              overflow: hidden;
              height: 130px;
            "
            class="q-px-md text-subtitle1 name"
          >
            {{ dish.description }}
          </div>
        </div>

        <div class="q-pl-xl q-ml-lg"></div>
        <div
          class="name text-subtitle2"
          style="position: absolute; right: 10px; bottom: 1px"
          @click="handleClick(dish.id)"
          flat
        >
          See more >>
        </div>
      </q-card>
    </div>

    <q-dialog
      v-model="visibleAddDishForm"
      persistent
      @hide="handleHideAddDishDialog"
    >
      <q-card class="q-py-sm full-width text-accent">
        <q-card-section
          class="q-ml-sm row full-width justify-between items-center"
        >
          <div class="text-h4 text-weight-medium name">
            Dodavanje novog jela
          </div>
          <q-btn
            icon="close"
            class="text-brown-5"
            flat
            round
            dense
            @click="handleHideAddDishDialog"
          />
        </q-card-section>

        <q-card-section class="q-pt-none">
          <q-form
            ref="form"
            class="full-width column q-gutter-y-md"
            @submit="handleSubmitRegisterForm"
          >
            <div class="name forma">
              <q-separator></q-separator>
              <div
                class="
                  row
                  justify-around
                  text-weight-medium text-h6
                  name
                  q-mt-lg
                "
                style="height: 35px"
              >
                <div class="col-6">Ime jela</div>
                <div class="col-6">
                  <div>Ubaci sliku</div>
                </div>
              </div>
              <div
                class="
                  row
                  justify-around
                  text-weight-medium text-h6
                  name
                  q-pt-md
                "
              >
                <div class="col-6 q-pr-sm">
                  <q-input filled v-model="name" label="Npr. Pizza" />
                </div>
                <div class="col-6">
                  <q-file
                    filled
                    bottom-slots
                    v-model="image"
                    label="Upload image"
                    counter
                  >
                    <template v-slot:append>
                      <q-icon
                        name="close"
                        @click.stop="model = null"
                        class="cursor-pointer"
                      />
                    </template>
                  </q-file>
                </div>
              </div>
              <div class="row text-h6 name">
                <div class="col-6">Dozvoli ocenjivanje jela</div>
                <div class="col-6">Da li je jelo ljuto?</div>
              </div>
              <div class="row justify-start text-h6 name">
                <div class="col-6">
                  <!--<q-option-group
                    v-model="group"
                    :options="options"
                    color="brown-4"
                    inline
                    class="text-subtitle1"
                  />-->
                  <q-radio color="brown-7" class="q-pr-sm" dense v-model="ocena" val="Da" label="Da"/>
                  <q-radio color="brown-7" dense v-model="ocena" val="Ne" label="Ne"/>
                </div>
                <div class="col-6">
                  <!--<q-option-group
                    v-model="group1"
                    :options="options1"
                    color="brown-4"
                    inline
                    class="text-subtitle1"
                  />-->
                  <q-radio class="q-pr-sm" color="brown-7" dense v-model="dishType" val="Da" label="Da"/>
                  <q-radio color="brown-7" dense v-model="dishType" val="Ne" label="Ne"/>
                </div>
              </div>
              <label class="text-h6 name q-pt-sm">Sastojci</label>
              <div class="row text-h6 name">
                <div v-for="(sastojak, index) in sastojci" :key="sastojak">
                  <div class="row justify-around q-pa-sm">
                    <q-btn
                      align="around"
                      class="btn-fixed-width"
                      text-color="brown-8"
                      color="grey-2"
                      @click="removeElement(index)"
                      >{{ sastojak }}
                      <div class="q-pb-md q-pl-md">x</div>
                    </q-btn>
                  </div>
                </div>
              </div>
              <div class="row text-h6 name q-py-md">
                <div style="max-width: 200px">
                  <q-input
                    filled
                    v-model="imeSastojka"
                    label="Napisi ime sastojka"
                  />
                </div>
                <div class="q-pt-sm q-pl-sm" @click="addsastojak">
                  <q-img class="pic" src="../../public/add.png" />
                </div>
              </div>
              <label class="text-h6 name q-py-sm">Opis jela</label>
              <div class="q-pt-md">
                <q-input filled v-model="opis" label="Napisi nesto o jelu..." />
              </div>
            </div>
          </q-form>
        </q-card-section>

        <q-card-actions align="right" class="bg-white text-teal">
          <q-btn class="backBtn" flat label="Dodaj jelo" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>
  </div>
</template>
<script>
import { mdiAlphaX } from "@mdi/js";
import { baseUrl } from "../services/apiConfig";
import { formRulesMixin } from "src/helper/formRulesMixin";
export default {
  mixins: [formRulesMixin],
  data() {
    return {
      dishType: "Da",
      ocena:"Da",
      model: null,
      ratingModel: 0,
      visibleAddDishForm: false,
      dishes: [],
      sastojci: [],
      sortingOptions: [],
      sortingOption: "",
      dishesForView: [],
      search: "",
      dishesPerPage: 8,
      usersRating: null,
      currentPage: 1,
      admin: false,
      userData: {},
      sortBool: false,
      imeSastojka: "",
      descriptionDish: "",
      formData: {
       
        name: "",
        image: "",
        picture: "",
        
        opis: "",
      },
    };
  },
  computed: {
    numOfDishes() {
      return this.dishesForView.length;
    },
    numOfPages() {
      if (this.numOfDishes % this.dishesPerPage == 0)
        return this.numOfDishes / this.dishesPerPage;
      else {
        return this.numOfDishes / this.dishesPerPage + 1;
      }
    },
  },
  watch: {
    search: function () {
      if (this.search == "") {
        this.dishesForView = this.dishes;
      } else {
        this.dishesForView = this.dishesForView.filter((dish) => {
          return dish.name.toLowerCase().startsWith(this.search.toLowerCase());
        });
      }
    },
  },
  filters: {
    ParseFloat(number) {
      let newValue = parseFloat(number).toFixed(2);
      return newValue;
    },
  },
  methods: {
    factoryFn(files) {
      return {
        url: "http://localhost:8080/upload",
        method: "POST",
      };
    },
    handleClick(id) {
      this.$router.push("dish/" + id);
    },
    addsastojak() {
      this.sastojci.push(this.imeSastojka);
      
      
    },
    removeElement: function (index) {
      this.sastojci.splice(index, 1);
    },
    handleClickPlus() {
      this.visibleAddDishForm = true;
    },
    handleHideAddDishDialog() {
      this.visibleAddDishForm = false;
    },
    sortDishes(option) {
      this.sortBool = true;
      this.dishesForView = [];
      this.dishes.forEach((element) => {
        if (element.dishType == option) this.dishesForView.push(element);
      });
    },
    getData() {
      this.$store
        .dispatch("apiRequest/getApiRequest", { url: "Dish" })
        .then((res) => {
          this.dishes = res;

          this.dishes.forEach((element) => {
            element.image = "data:image/png;base64," + element.image;
          });
          this.dishesForView = this.dishes;
        });
    },
    getDishTypes() {
      this.$store
        .dispatch("apiRequest/getApiRequest", { url: `/dish/dishTypes` })
        .then((res) => {
          this.sortingOptions = res;
        });
    },

    getUsersData() {
      this.$store
        .dispatch("apiRequest/getApiRequest", { url: "user/0" })
        .then((res) => {
          this.userData = res;
          this.check();
        });
    },
    check() {
      this.userData.roles.forEach((el) => {
        if (el == "admin") return (this.admin = true);
      });
    },
  },
  created() {
    this.getData();
    this.getDishTypes();
    this.getUsersData();
  },
};
</script>

<style scoped>
.cards {
  justify-content: center;
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  position: relative;
}

.my-card,
.addCard {
  width: 260px;
  height: 505px;
  margin: 59px 20px 31px;
  padding: 0 0 29px;
  background-color: #fbfbfb;
  display: flex;
  flex-direction: column;
}

.name {
  color: #5c5840;
}
.hidden1 {
  display: none;
}
.firstCard {
  width: 29.3px;
  height: 29.3px;
  background-color: #fbfbfb;
  display: flex;
}
.cup {
  width: 185px;
  height: 230px;
}
.cardClass {
  display: flex;
  flex-direction: column;
  justify-items: stretch;
}
.picture {
  width: 100%;
  height: 280px;
}
.forma {
  justify-content: center;
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  position: relative;
}
.pic {
  width: 19.5px;
  height: 19.5px;
}
.backBtn {
  background-color: #5c5840;
  color: white;
}
</style>
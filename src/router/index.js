import { createRouter, createWebHistory } from 'vue-router'
import Home from '../components/Home.vue'
import Contacts from '../components/Contacts.vue'
import Faq from "..//components/Faq.vue"
import Page404 from "..//components/Page404.vue"
// Если у вас есть другие страницы (404, FAQ, Рецепты, Профиль) – импортируйте их
// import Faq from '../components/Faq.vue'
// import Recipes from '../components/Recipes.vue'
// import Profile from '../components/Profile.vue'
// import NotFound from '../components/404.vue'

const routes = [
  { path: '/', name: 'home', component: Home },
  { path: '/contacts', name: 'contacts', component: Contacts },
  { path: '/faq', name: 'faq', component: Faq },
  { path: '/Page404', name: 'Page404', component: Page404 },
  // остальные маршруты
  // { path: '/faq', component: Faq },
  // { path: '/recipes', component: Recipes },
  // { path: '/profile', component: Profile },
  // { path: '/:pathMatch(.*)*', name: 'not-found', component: NotFound }, // 404
]

const router = createRouter({
  history: createWebHistory(),
  routes,
  scrollBehavior(to, from, savedPosition) {
    if (to.hash) {
      return { el: to.hash, behavior: 'smooth' }
    } else if (savedPosition) {
      return savedPosition
    } else {
      return { top: 0 }
    }
  }
})

export default router